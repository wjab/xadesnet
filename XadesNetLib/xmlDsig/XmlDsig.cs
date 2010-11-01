using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using XadesNetLib.xmlDsig.dsl;

namespace XadesNetLib.xmlDsig
{
    public abstract class XmlDsig
    {
        internal static void SignDocument(XmlDsigSignParameters signParameters)
        {
            ValidateParameters(signParameters);

            var xmlAFirmar = new XmlDocument();
            xmlAFirmar.Load(signParameters.InputPath);

            var signature = GetSignature(xmlAFirmar, signParameters.SignatureCertificate,
                signParameters.SignatureFormat);
            var signatureXml = signature.GetXml();
            if (XmlDsigSignatureFormat.Enveloping.Equals(signParameters.SignatureFormat))
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(signatureXml.OuterXml);
                xmlDocument.Save(signParameters.OutputPath);
            }
            if (XmlDsigSignatureFormat.Enveloped.Equals(signParameters.SignatureFormat))
            {
                var raiz = xmlAFirmar.DocumentElement;
                if (raiz != null) raiz.AppendChild(xmlAFirmar.ImportNode(signatureXml, true));
                xmlAFirmar.Save(signParameters.OutputPath);
            }
        }
        internal static bool ValidateDocument(XmlDsigValidationParameters validationParameters)
        {
            var xmlDocument = new XmlDocument { PreserveWhitespace = false };
            xmlDocument.LoadXml(File.ReadAllText(validationParameters.InputPath));
            var xml = xmlDocument.OuterXml;
            return PerformValidationFromXml(xml, validationParameters);
        }

        private static bool PerformValidationFromXml(string xml, XmlDsigValidationParameters validationParameters)
        {
            var document = new XmlDocument { PreserveWhitespace = false };
            document.LoadXml(xml);

            var newsignedXml = new SignedXml(document);
            if (document.DocumentElement == null) throw new InvalidDocumentException("Document has no root element");
            if (document.DocumentElement.Name.Equals("Signature"))
            {
                newsignedXml.LoadXml(document.DocumentElement);                
            }
            else
            {
                var nsMgr = new XmlNamespaceManager(document.NameTable);
                nsMgr.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");
                var signatureElement = document.DocumentElement.SelectSingleNode("ds:Signature", nsMgr) as XmlElement;
                if (signatureElement == null) throw new InvalidSignedDocumentException("'Signature' node not found in enveloped signature");
                newsignedXml.LoadXml(signatureElement);
            }

            var validationCertificate = validationParameters.ValidationCertificate;
            if (validationCertificate == null)
            {
                if (newsignedXml.KeyInfo != null)
                {
                    var certificates = newsignedXml.KeyInfo.GetEnumerator();
                    if (certificates.MoveNext())
                    {
                        var x509Data = (KeyInfoX509Data)certificates.Current;
                        if (x509Data != null)
                        {
                            if (x509Data.Certificates.Count > 0)
                                validationCertificate = (X509Certificate2)x509Data.Certificates[0];
                        }
                    }
                }
            }
            if (validationCertificate == null) throw new Exception("Signer public key could not be found");
            if (!newsignedXml.CheckSignature(validationCertificate, !validationParameters.ValidateCertificate))
            {
                throw new InvalidOperationException("Signature is invalid.");
            }
            return true;
        }

        private static void ValidateParameters(XmlDsigSignParameters signParameters)
        {
            if (signParameters == null) throw new InvalidParameterException("Parameters to sign cannot be null");
            if (signParameters.SignatureCertificate == null) throw new InvalidParameterException("Signer Certificate cannot be null");
            if (signParameters.InputPath == null) throw new InvalidParameterException("Document to sign cannot be null");
            if (signParameters.OutputPath == null) throw new InvalidParameterException("Path of signed file cannot be null");
        }

        private static SignedXml GetSignature(XmlDocument document, X509Certificate2 certificate, XmlDsigSignatureFormat format)
        {
            if (document.DocumentElement == null) throw new InvalidDocumentException("Document to sign has no root element");

            var signedXml = new SignedXml(document);
            signedXml.AddReference(CreateReference(format));
            if (XmlDsigSignatureFormat.Enveloping.Equals(format))
            {
                var dataObject = new DataObject("documentdata", "", "", document.DocumentElement);
                signedXml.AddObject(dataObject);
            }
            signedXml.SigningKey = certificate.PrivateKey;
            signedXml.KeyInfo = CreateKeyInfo(certificate);
            if (XmlDsigSignatureFormat.Enveloping.Equals(format))
            {
                signedXml.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigExcC14NTransformUrl;
            }
            signedXml.ComputeSignature();

            return signedXml;
        }

        private static Reference CreateReference(XmlDsigSignatureFormat format)
        {
            Reference signatureReference;
            if (XmlDsigSignatureFormat.Enveloping.Equals(format))
            {
                signatureReference = new Reference("#documentdata");
                signatureReference.AddTransform(new XmlDsigExcC14NTransform());
                return signatureReference;
            }
            signatureReference = new Reference { Uri = "" };
            signatureReference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            return signatureReference;
        }

        private static KeyInfo CreateKeyInfo(X509Certificate certificate)
        {
            var certificateKeyInfo = new KeyInfo();
            certificateKeyInfo.AddClause(new KeyInfoX509Data(certificate));
            return certificateKeyInfo;
        }

        public static SignDSL Sign(string inputPath)
        {
            var signDsl = new SignDSL();
            signDsl.InputPath(inputPath);
            return signDsl;
        }

        public static ValidationDSL Validate(string signaturePath)
        {
            var validationDsl = new ValidationDSL();
            validationDsl.SignaturePath(signaturePath);
            return validationDsl;
        }
    }
}

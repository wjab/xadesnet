using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace XadesNetLib.xmlDsig
{
    public abstract class XmlDsig
    {
        public static void SignDocument(XmlDsigSignParameters signParameters)
        {
            Validate(signParameters);

            var signature = GetSignature(signParameters.XmlDeEntrada, signParameters.CertificadoDeFirma,
                signParameters.FormatoDeFirma);
            var signatureXml = signature.GetXml();
            if (XmlDsigSignatureFormat.Enveloping.Equals(signParameters.FormatoDeFirma))
            {
                var xmlDocument = new XmlDocument();
                xmlDocument.LoadXml(signatureXml.OuterXml);
                xmlDocument.Save(signParameters.PathSalida);
            }
            if (XmlDsigSignatureFormat.Enveloped.Equals(signParameters.FormatoDeFirma))
            {
                if (signParameters.XmlDeEntrada.DocumentElement != null)
                    signParameters.XmlDeEntrada.DocumentElement.AppendChild(signParameters.XmlDeEntrada.ImportNode(signatureXml, true));
                signParameters.XmlDeEntrada.Save(signParameters.PathSalida);
            }
        }
        public static bool ValidateDocument(XmlDsigValidationParameters validationParameters)
        {
            var xmlDocument = new XmlDocument { PreserveWhitespace = false };
            xmlDocument.LoadXml(File.ReadAllText(validationParameters.PathDocumento));
            var xml = xmlDocument.OuterXml;
            return PerformValidationFromXml(xml, validationParameters);
        }

        private static bool PerformValidationFromXml(string xml, XmlDsigValidationParameters validationParameters)
        {
            var document = new XmlDocument { PreserveWhitespace = false };
            document.LoadXml(xml);

            var newsignedXml = new SignedXml(document);
            if (document.DocumentElement == null) throw new InvalidDocumentException("Document has no root element");
            newsignedXml.LoadXml(document.DocumentElement);

            var validationCertificate = validationParameters.CertificadoValidacion;
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
            if (!newsignedXml.CheckSignature(validationCertificate, validationParameters.ValidarTambienElCertificado))
            {
                throw new InvalidOperationException("Signature is invalid.");
            }
            return true;
        }

        private static void Validate(XmlDsigSignParameters signParameters)
        {
            if (signParameters == null) throw new InvalidParameterException("Parameters to sign cannot be null");
            if (signParameters.CertificadoDeFirma == null) throw new InvalidParameterException("Signer Certificate cannot be null");
            if (signParameters.XmlDeEntrada == null) throw new InvalidParameterException("Document to sign cannot be null");
            if (signParameters.PathSalida == null) throw new Exception("Path of signed file cannot be null");
            if (signParameters.XmlDeEntrada.DocumentElement == null) throw new InvalidDocumentException("Document to sign has no root element");
        }

        private static SignedXml GetSignature(XmlDocument document, X509Certificate2 certificate, XmlDsigSignatureFormat format)
        {
            if (document.DocumentElement == null) throw new InvalidDocumentException("Document to sign has no root element");

            var signedXml = new SignedXml(document);
            var dataObject = new DataObject("message", "", "", document.DocumentElement);

            signedXml.AddReference(CreateReference(format));
            if (XmlDsigSignatureFormat.Enveloping.Equals(format))
            {
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
                signatureReference = new Reference("#message");
                signatureReference.AddTransform(new XmlDsigExcC14NTransform());
                return signatureReference;
            }
            signatureReference = new Reference();
            signatureReference.Uri = "";
            signatureReference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            return signatureReference;
        }

        private static KeyInfo CreateKeyInfo(X509Certificate certificate)
        {
            var certificateKeyInfo = new KeyInfo();
            certificateKeyInfo.AddClause(new KeyInfoX509Data(certificate));
            return certificateKeyInfo;
        }
    }
}

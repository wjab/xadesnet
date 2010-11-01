using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace XadesNetLib.xmlDsig.signing
{
    public abstract class Validator
    {
        public static bool Validate(XmlDsigValidationParameters parameters)
        {
            var xmlDocument = new XmlDocument { PreserveWhitespace = false };
            xmlDocument.LoadXml(File.ReadAllText(parameters.InputPath));
            var xml = xmlDocument.OuterXml;
            return PerformValidationFromXml(xml, parameters);
        }
        private static bool PerformValidationFromXml(string xml, XmlDsigValidationParameters validationParameters)
        {
            var document = new XmlDocument { PreserveWhitespace = false };
            document.LoadXml(xml);

            var newsignedXml = new SignedXml(document);
            if (document.DocumentElement == null) throw new InvalidDocumentException("Document has no root element");

            newsignedXml.LoadXml(GetSignatureNode(document));

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

        protected static XmlElement GetSignatureNode(XmlDocument document)
        {
            if (document.DocumentElement.Name.Equals("Signature"))
            {
                return document.DocumentElement;
            }
            var nsMgr = new XmlNamespaceManager(document.NameTable);
            nsMgr.AddNamespace("ds", "http://www.w3.org/2000/09/xmldsig#");
            var signatureElement = document.DocumentElement.SelectSingleNode("ds:Signature", nsMgr) as XmlElement;
            if (signatureElement == null)
                throw new InvalidSignedDocumentException("'Signature' node not found in enveloped signature");
            return signatureElement;
        }
    }
}
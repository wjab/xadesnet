using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using XadesNetLib.Exceptions;
using XadesNetLib.Signatures.Verification;
using XadesNetLib.XmlDsig.Common;
using XadesNetLib.Xml;
using XadesNetLib.XmlDsig.Helpers;

namespace XadesNetLib.XmlDsig.Operations
{
    internal abstract class XmlDsigVerifyOperation
    {
        internal static bool Verify(VerificationParameters parameters)
        {
            VerifyAndGetResults(parameters);
            return true;
        }
        internal static VerificationResults VerifyAndGetResults(VerificationParameters parameters)
        {
            //XmlHelper.ValidateFromSchemas(parameters.InputPath,
            //                              new XmlSchemaDescriptor
            //                                  {
            //                                      Namespace = SignedXml.XmlDsigNamespaceUrl,
            //                                      Path = "Schemas/xmldsig-core-schema.xsd"
            //                                  });
            var xmlDocument = new XmlDocument { PreserveWhitespace = false };
            xmlDocument.LoadXml(File.ReadAllText(parameters.InputPath));
            var xml = xmlDocument.OuterXml;
            return PerformValidationFromXml(xml, parameters);
        }

        #region Private methods

        private static VerificationResults PerformValidationFromXml(string xml, VerificationParameters validationParameters)
        {
            var document = new XmlDocument { PreserveWhitespace = false };
            document.LoadXml(xml);

            var newsignedXml = new SignedXml(document);
            if (document.DocumentElement == null) throw new InvalidDocumentException("Document has no root element");

            newsignedXml.LoadXml(XmlDsigNodesHelper.GetSignatureNode(document));

            var verificationCertificate = GetVerificationCertificate(newsignedXml, validationParameters);
            if (verificationCertificate == null) throw new Exception("Signer public key could not be found");
            if (!newsignedXml.CheckSignature(verificationCertificate, !validationParameters.VerifyCertificate))
            {
                throw new InvalidOperationException("Signature is invalid.");
            }
            var results = new VerificationResults
                              {
                                  Timestamp = GetTimeStampFromSignature(document),
                                  OriginalDocument = GetDocumentFromSignature(document),
                                  SigningCertificate = GetCertificateFromSignature(document)
                              };
            return results;
        }
        private static X509Certificate2 GetVerificationCertificate(SignedXml signedXml, VerificationParameters verificationParameters)
        {
            var validationCertificate = verificationParameters.VerificationCertificate;
            if (validationCertificate == null)
            {
                if (signedXml.KeyInfo != null)
                {
                    var certificates = signedXml.KeyInfo.GetEnumerator();
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
            return validationCertificate;
        }
        private static X509Certificate2 GetCertificateFromSignature(XmlDocument signedXml)
        {
            var signatureNode = signedXml.DocumentElement;
            if (!XmlDsigNodesHelper.IsSignatureNode(signatureNode))
            {
                signatureNode = XmlHelper.DescendantWith(signatureNode, XmlDsigNodesHelper.IsSignatureNode);
            }
            var keyInfoNode = XmlHelper.DescendantWith(signatureNode, XmlDsigNodesHelper.IsKeyInfo);
            var x509Data = XmlHelper.DescendantWith(keyInfoNode, XmlDsigNodesHelper.IsX509Data);
            var x509Certificate = XmlHelper.DescendantWith(x509Data, XmlDsigNodesHelper.IsX509Certificate);
            return new X509Certificate2(Convert.FromBase64String(x509Certificate.InnerText));
        }

        #region Recover Original Document

        private static XmlDocument GetDocumentFromSignature(XmlDocument signedXml)
        {
            var rootNode = signedXml.DocumentElement;
            if (XmlDsigNodesHelper.IsSignatureNode(rootNode))
            {
                return GetDocumentFromDetachedOrEnvelopingSignature(signedXml);
            }
            return GetDocumentFromEnvelopedSignature(signedXml);
        }
        private static XmlDocument GetDocumentFromDetachedOrEnvelopingSignature(XmlDocument signedXml)
        {
            var signedInfoNode = XmlHelper.DescendantWith(signedXml.DocumentElement, XmlDsigNodesHelper.IsSignedInfoNode);
            var referenceToContentsNode = XmlHelper.DescendantWith(signedInfoNode, XmlDsigNodesHelper.IsReferenceToOriginalContent);
            if (referenceToContentsNode == null) throw new Exception("Reference to Original Content not found");
            var uri = XmlHelper.AttributeOf(referenceToContentsNode, "URI");
            if (uri.StartsWith("#")) uri = uri.Substring(1);
            if (XmlDsigNodesHelper.ReferenceIsDetached(referenceToContentsNode))
            {
                return XmlHelper.ReadXmlFromUri(uri);
            }
            var results = new XmlDocument();
            var contentsNode = XmlHelper.DescendantWith(signedXml.DocumentElement, n => XmlDsigNodesHelper.ObjectNodeWithIdAsUri(n, uri));
            results.LoadXml(contentsNode.InnerXml);
            return results;
        }
        private static XmlDocument GetDocumentFromEnvelopedSignature(XmlDocument signedXml)
        {
            if (signedXml.DocumentElement == null) 
                throw new InvalidParameterException("Root node cannot be found in signed XML");
            var results = new XmlDocument();
            results.LoadXml(signedXml.OuterXml);
            var rootNodeOfResults = results.DocumentElement;
            if (rootNodeOfResults == null) throw new InvalidParameterException("Root node cannot be found in signed XML");
            var signatureNode = XmlHelper.DescendantWith(rootNodeOfResults, XmlDsigNodesHelper.IsSignatureNode);
            rootNodeOfResults.RemoveChild(signatureNode);
            return results;
        }

        #endregion
        #region Timestamping

        private static string GetTimeStampFromSignature(XmlDocument document)
        {
            var rootNode = document.DocumentElement;
            var signatureNode = XmlDsigNodesHelper.IsSignatureNode(rootNode) ?
                rootNode : XmlHelper.DescendantWith(rootNode, XmlDsigNodesHelper.IsSignatureNode);
            if (signatureNode == null) throw new Exception("Signature node not found");
            var timestamps = XmlHelper.FindNodesIn(signatureNode, "Object/SignatureProperties/SignatureProperty/Timestamp");
            return timestamps.Count == 0 ? "" : timestamps[0].InnerText;
        }

        #endregion

        #endregion
    }
}
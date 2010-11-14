using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using XadesNetLib.Common;
using XadesNetLib.Exceptions;
using XadesNetLib.XmlDsig.Common;
using XadesNetLib.Xml;

namespace XadesNetLib.XmlDsig.Signing
{
    public abstract class Verifier
    {
        internal static bool Verify(XmlDsigValidationParameters parameters)
        {
            VerifyAndGetResults(parameters);
            return true;
        }
        internal static VerificationResults VerifyAndGetResults(XmlDsigValidationParameters parameters)
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

        private static VerificationResults PerformValidationFromXml(string xml, XmlDsigValidationParameters validationParameters)
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
            var results = new VerificationResults
                              {
                                  Timestamp = GetTimeStampFromSignature(document),
                                  OriginalDocument = GetDocumentFromSignature(document),
                                  SigningCertificate = GetCertificateFromSignature(document)
                              };
            return results;
        }

        private static X509Certificate2 GetCertificateFromSignature(XmlDocument signedXml)
        {
            var signatureNode = signedXml.DocumentElement;
            if (!IsSignatureNode(signatureNode))
            {
                signatureNode = XmlHelper.DescendantWith(signatureNode, IsSignatureNode);
            }
            var keyInfoNode = XmlHelper.DescendantWith(signatureNode, IsKeyInfo);
            var x509Data = XmlHelper.DescendantWith(keyInfoNode, IsX509Data);
            var x509Certificate = XmlHelper.DescendantWith(x509Data, IsX509Certificate);
            return new X509Certificate2(Convert.FromBase64String(x509Certificate.InnerText));
        }

        private static bool IsX509Certificate(XmlElement node)
        {
            return "X509Certificate".Equals(node.Name) && SignedXml.XmlDsigNamespaceUrl.Equals(node.NamespaceURI);
        }
        private static bool IsX509Data(XmlElement node)
        {
            return "X509Data".Equals(node.Name) && SignedXml.XmlDsigNamespaceUrl.Equals(node.NamespaceURI);
        }
        private static bool IsKeyInfo(XmlElement node)
        {
            return "KeyInfo".Equals(node.Name) && SignedXml.XmlDsigNamespaceUrl.Equals(node.NamespaceURI);
        }

        #region Recover Original Document

        private static XmlDocument GetDocumentFromSignature(XmlDocument signedXml)
        {
            var rootNode = signedXml.DocumentElement;
            if (IsSignatureNode(rootNode))
            {
                return GetDocumentFromDetachedOrEnvelopingSignature(signedXml);
            }
            return GetDocumentFromEnvelopedSignature(signedXml);
        }

        private static XmlDocument GetDocumentFromDetachedOrEnvelopingSignature(XmlDocument signedXml)
        {
            var signedInfoNode = XmlHelper.DescendantWith(signedXml.DocumentElement, IsSignedInfoNode);
            var referenceToContentsNode = XmlHelper.DescendantWith(signedInfoNode, IsReferenceToOriginalContent);
            if (referenceToContentsNode == null) throw new Exception("Reference to Original Content not found");
            var uri = XmlHelper.AttributeOf(referenceToContentsNode, "URI");
            if (uri.StartsWith("#")) uri = uri.Substring(1);
            if (ReferenceIsDetached(referenceToContentsNode))
            {
                return XmlHelper.ReadXmlFromUri(uri);
            }
            var results = new XmlDocument();
            var contentsNode = XmlHelper.DescendantWith(signedXml.DocumentElement, n => ObjectNodeWithIdAsUri(n, uri));
            results.LoadXml(contentsNode.InnerXml);
            return results;
        }

        private static bool ObjectNodeWithIdAsUri(XmlElement n, string uri)
        {
            return "Object".Equals(n.Name) &&
                   SignedXml.XmlDsigNamespaceUrl.Equals(n.NamespaceURI) &&
                   uri.Equals(XmlHelper.AttributeOf(n, "Id"));
        }

        private static bool IsSignedInfoNode(XmlElement node)
        {
            if (node == null) return false;
            return "SignedInfo".Equals(node.Name) && SignedXml.XmlDsigNamespaceUrl.Equals(node.NamespaceURI);
        }

        private static bool ReferenceIsDetached(XmlElement referenceToContentsNode)
        {
            return !referenceToContentsNode.Attributes["URI"].Value.StartsWith("#");
        }

        private static bool IsReferenceToOriginalContent(XmlElement node)
        {
            if (node == null) return false;
            var nameIsReference = "Reference".Equals(node.Name);
            var nameSpaceIsXmlDSig = SignedXml.XmlDsigNamespaceUrl.Equals(node.NamespaceURI);
            var typeAttribute = node.Attributes["Type"];
            var typeIsNotSignatureProperties = true;
            if (typeAttribute != null)
            {
                typeIsNotSignatureProperties = ExtendedSignedXml.XmlDsigSignatureProperties.Equals(typeAttribute.Value);
            }
            return (nameIsReference && nameSpaceIsXmlDSig && typeIsNotSignatureProperties);
        }

        private static XmlDocument GetDocumentFromEnvelopedSignature(XmlDocument signedXml)
        {
            if (signedXml.DocumentElement == null) 
                throw new InvalidParameterException("Root node cannot be found in signed XML");
            var results = new XmlDocument();
            results.LoadXml(signedXml.OuterXml);
            var rootNodeOfResults = results.DocumentElement;
            if (rootNodeOfResults == null) throw new InvalidParameterException("Root node cannot be found in signed XML");
            var signatureNode = XmlHelper.DescendantWith(rootNodeOfResults, IsSignatureNode);
            rootNodeOfResults.RemoveChild(signatureNode);
            return results;
        }

        #endregion

        private static string GetTimeStampFromSignature(XmlDocument document)
        {
            var rootNode = document.DocumentElement;
            var signatureNode = IsSignatureNode(rootNode) ? rootNode : XmlHelper.DescendantWith(rootNode, IsSignatureNode);
            if (signatureNode == null) throw new Exception("Signature node not found");
            var timestamps = XmlHelper.FindNodesIn(signatureNode, "Object/SignatureProperties/SignatureProperty/Timestamp");
            return timestamps.Count == 0 ? "" : timestamps[0].InnerText;
        }

        private static bool IsSignatureNode(XmlElement node)
        {
            if (node == null) throw new Exception("Node cannot be null");
            return "Signature".Equals(node.Name) && SignedXml.XmlDsigNamespaceUrl.Equals(node.NamespaceURI);
        }

        protected static XmlElement GetSignatureNode(XmlDocument document)
        {
            if (document == null)
            {
                throw new InvalidParameterException("Xml document cannot be null");
            }
            if (document.DocumentElement == null)
            {
                throw new InvalidParameterException("Xml document must have root element");
            }

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
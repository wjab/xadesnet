using System;
using System.Security.Cryptography.Xml;
using System.Xml;
using XadesNetLib.Common;
using XadesNetLib.Exceptions;
using XadesNetLib.Xml;

namespace XadesNetLib.XmlDsig.Helpers
{
    internal class XmlDsigNodesHelper
    {
        private XmlDsigNodesHelper()
        {
        }

        internal static bool ObjectNodeWithIdAsUri(XmlElement n, string uri)
        {
            return "Object".Equals(n.Name) &&
                   SignedXml.XmlDsigNamespaceUrl.Equals(n.NamespaceURI) &&
                   uri.Equals(XmlHelper.AttributeOf(n, "Id"));
        }

        internal static bool IsSignedInfoNode(XmlElement node)
        {
            if (node == null) return false;
            return "SignedInfo".Equals(node.Name) && SignedXml.XmlDsigNamespaceUrl.Equals(node.NamespaceURI);
        }
        internal static bool IsX509Certificate(XmlElement node)
        {
            return "X509Certificate".Equals(node.Name) && SignedXml.XmlDsigNamespaceUrl.Equals(node.NamespaceURI);
        }
        internal static bool IsX509Data(XmlElement node)
        {
            return "X509Data".Equals(node.Name) && SignedXml.XmlDsigNamespaceUrl.Equals(node.NamespaceURI);
        }
        internal static bool IsKeyInfo(XmlElement node)
        {
            return "KeyInfo".Equals(node.Name) && SignedXml.XmlDsigNamespaceUrl.Equals(node.NamespaceURI);
        }
        internal static bool IsSignatureNode(XmlElement node)
        {
            if (node == null) throw new Exception("Node cannot be null");
            return "Signature".Equals(node.Name) && SignedXml.XmlDsigNamespaceUrl.Equals(node.NamespaceURI);
        }
        internal static bool IsReferenceToOriginalContent(XmlElement node)
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

        internal static bool ReferenceIsDetached(XmlElement referenceToContentsNode)
        {
            return !referenceToContentsNode.Attributes["URI"].Value.StartsWith("#");
        }

        internal static XmlElement GetSignatureNode(XmlDocument document)
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
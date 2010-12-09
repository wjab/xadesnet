using System.Security.Cryptography.Xml;
using System.Xml;
using XadesNetLib.Common;
using XadesNetLib.Xades.Common;
using XadesNetLib.Xml;
using XadesNetLib.XmlDsig.Common;
using XadesNetLib.XmlDsig.Operations;
using XadesNetLib.Cryptography;

namespace XadesNetLib.Xades.Operations
{
    public abstract class XadesSignOperation
    {
        public const string XadesNamespaceUrl = "http://uri.etsi.org/01903/v1.3.2#";

        public static void SignToFile(XadesSignParameters parameters)
        {
            var xmlDSigParameters = CreateXmlDSigParametersFrom(parameters);
            XmlDsigSignOperation.From(xmlDSigParameters).Sign(xmlDSigParameters, signedXml => AddXAdESNodes(signedXml, xmlDSigParameters));
        }

        public static XmlDocument SignAndGetXml(XadesSignParameters parameters)
        {
            var xmlDSigParameters = CreateXmlDSigParametersFrom(parameters);
            return XmlDsigSignOperation.From(xmlDSigParameters).SignAndGetXml(xmlDSigParameters, signedXml => AddXAdESNodes(signedXml, xmlDSigParameters));
        }

        private static void AddXAdESNodes(ExtendedSignedXml signedXml, XmlDsigSignParameters parameters)
        {
            var document = parameters.InputXml;
            var qualifyingPropertiesNode = AddQualifyingPropertiesNode(signedXml, document);
            var signedPropertiesNode = AddSignedPropertiesNode(document, qualifyingPropertiesNode);
            CreateReferenceToSignedProperties(signedXml, signedPropertiesNode);
            var signedSignatureProperties = AddSignedSignaturePropertiesNode(document, signedPropertiesNode);
            AddSigningTimeNode(document, signedSignatureProperties);
            AddSigningCertificate(document, signedSignatureProperties, parameters);
            //AddSignaturePolicyIdentifier(document, signedSignatureProperties);
            var unsignedPropertiesNode = AddUnsignedPropertiesNode(document, qualifyingPropertiesNode);
            AddUnsignedSignaturePropertiesNode(document, unsignedPropertiesNode);
        }

        private static void CreateReferenceToSignedProperties(ExtendedSignedXml signedXml, XmlElement signedPropertiesNode)
        {
            var reference = new Reference("#" + signedPropertiesNode.GetAttribute("Id"))
                                {
                                    Type = ExtendedSignedXml.XmlDsigSignatureProperties
                                };
            signedXml.AddReference(reference);
        }

        private static XmlElement AddQualifyingPropertiesNode(ExtendedSignedXml signedXml, XmlDocument document)
        {
            var dataObject = new DataObject();
            var result = document.CreateElement("QualifyingProperties", XadesNamespaceUrl);
            result.SetAttribute("Target", signedXml.Signature.Id);
            dataObject.Data = result.SelectNodes(".");
            signedXml.AddObject(dataObject);
            return result;
        }
        private static XmlElement AddSignedPropertiesNode(XmlDocument document, XmlElement qualifyingPropertiesNode)
        {
            var signedPropertiesNode = XmlHelper.CreateNodeIn(document, "SignedProperties", XadesNamespaceUrl, qualifyingPropertiesNode);
            signedPropertiesNode.SetAttribute("Id", "xadesSignedProperties");
            return signedPropertiesNode;
        }

        private static XmlElement AddSignedSignaturePropertiesNode(XmlDocument document, XmlElement propertiesNode)
        {
            return XmlHelper.CreateNodeIn(document, "SignedSignatureProperties", XadesNamespaceUrl, propertiesNode);
        }
        private static void AddSigningTimeNode(XmlDocument document, XmlElement signedSignaturePropertiesNode)
        {
            XmlHelper.CreateNodeWithTextIn(document, "SigningTime", XmlHelper.NowInCanonicalRepresentation(),
                XadesNamespaceUrl, signedSignaturePropertiesNode);
        }
        private static void AddSigningCertificate(XmlDocument document, XmlElement signedSignatureProperties, XmlDsigSignParameters parameters)
        {
            var signingCertificateNode = XmlHelper.CreateNodeIn(document, "SigningCertificate", XadesNamespaceUrl, signedSignatureProperties);
            var certNode = XmlHelper.CreateNodeIn(document, "Cert", XadesNamespaceUrl, signingCertificateNode);
            AddCertDigestNode(document, certNode, parameters);
            AddIssuerSerialNode(document, certNode, parameters);
        }
        private static void AddCertDigestNode(XmlDocument document, XmlElement certNode, XmlDsigSignParameters parameters)
        {
            var certDigestNode = XmlHelper.CreateNodeIn(document, "CertDigest", XadesNamespaceUrl, certNode);
            XmlHelper.CreateNodeWithTextIn(document, "DigestMethod", SignedXml.XmlDsigSHA1Url, SignedXml.XmlDsigNamespaceUrl, certDigestNode);
            var certificateData = parameters.SignatureCertificate.RawData;
            var digestValue = CryptoHelper.GetBase64SHA1(certificateData);
            XmlHelper.CreateNodeWithTextIn(document, "DigestValue", digestValue, SignedXml.XmlDsigNamespaceUrl, certDigestNode);
        }
        private static void AddIssuerSerialNode(XmlDocument document, XmlElement certNode, XmlDsigSignParameters parameters)
        {
            var issuerSerialNode = XmlHelper.CreateNodeIn(document, "IssuerSerial", XadesNamespaceUrl, certNode);
            XmlHelper.CreateNodeWithTextIn(document, "X509IssuerName", parameters.SignatureCertificate.Issuer,
                                           SignedXml.XmlDsigNamespaceUrl, issuerSerialNode);
            XmlHelper.CreateNodeWithTextIn(document, "X509SerialNumber", parameters.SignatureCertificate.SerialNumber,
                                           SignedXml.XmlDsigNamespaceUrl, issuerSerialNode);
        }

        private static XmlElement AddUnsignedPropertiesNode(XmlDocument document, XmlElement qualifyingPropertiesNode)
        {
            return XmlHelper.CreateNodeIn(document, "UnsignedProperties", XadesNamespaceUrl, qualifyingPropertiesNode);
        }
        private static XmlElement AddUnsignedSignaturePropertiesNode(XmlDocument document, XmlElement unsignedPropertiesNode)
        {
            return XmlHelper.CreateNodeIn(document, "UnsignedSignatureProperties", XadesNamespaceUrl, unsignedPropertiesNode);
        }

        private static XmlDsigSignParameters CreateXmlDSigParametersFrom(XadesSignParameters xadesSignParameters)
        {
            return new XmlDsigSignParameters
            {
                IncludeCertificateInSignature = xadesSignParameters.IncludeCertificateInSignature,
                IncludeTimestamp = false,
                InputPath = xadesSignParameters.InputPath,
                InputXml = xadesSignParameters.InputXml,
                OutputPath = xadesSignParameters.OutputPath,
                Properties = xadesSignParameters.Properties,
                PropertyBuilders = xadesSignParameters.PropertyBuilders,
                SignatureCertificate = xadesSignParameters.SignatureCertificate,
                SignatureFormat = XmlDsigSignatureFormat.Enveloped
            };
        }
    }
}
using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using XadesNetLib.Common;
using XadesNetLib.XmlDsig.Common;
using XadesNetLib.XmlDsig.Signing;

namespace XadesNetLib.XmlDsig.Dsl
{
    public class SignDSL
    {
        private readonly XmlDsigSignParameters _parameters = new XmlDsigSignParameters();

        public SignDSL InputPath(string inputPath)
        {
            _parameters.InputPath = inputPath;
            _parameters.InputXml = null;
            return this;
        }
        public SignDSL InputXml(XmlDocument xmlDocument)
        {
            _parameters.InputXml = xmlDocument;
            _parameters.InputPath = string.Empty;
            return this;
        }

        public SignDSL Using(X509Certificate2 certificate)
        {
            _parameters.SignatureCertificate = certificate;
            return this;
        }

        public SignDSL Enveloping()
        {
            _parameters.SignatureFormat = XmlDsigSignatureFormat.Enveloping;
            return this;
        }
        public SignDSL Enveloped()
        {
            _parameters.SignatureFormat = XmlDsigSignatureFormat.Enveloping;
            return this;
        }
        public SignDSL Detached()
        {
            _parameters.SignatureFormat = XmlDsigSignatureFormat.Detached;
            return this;
        }

        public SignDSL UsingFormat(XmlDsigSignatureFormat xmlDsigSignatureFormat)
        {
            _parameters.SignatureFormat = xmlDsigSignatureFormat;
            return this;
        }

        public SignDSL IncludingCertificateInSignature()
        {
            _parameters.IncludeCertificateInSignature = true;
            return this;
        }
        public SignDSL DoNotIncludeCertificateInSignature()
        {
            _parameters.IncludeCertificateInSignature = false;
            return this;
        }
        public SignDSL IncludeTimestamp(bool includeTimestamp)
        {
            _parameters.IncludeTimestamp = includeTimestamp;
            return this;
        }
        public SignDSL WithProperty(string propertyName, string propertyValue)
        {
            _parameters.Properties.Add(new XmlPropertyDescriptor
            {
                Name = propertyName,
                Value = propertyValue
            });
            return this;
        }
        public SignDSL WithProperty(string propertyName, string propertyValue, string propertyNameSpace)
        {
            _parameters.Properties.Add(new XmlPropertyDescriptor
                                           {
                                               Name = propertyName,
                                               Value = propertyValue,
                                               NameSpace = propertyNameSpace
                                           });
            return this;
        }
        public SignDSL WithPropertyBuiltFromDoc(Converter<XmlDocument, XmlElement> howToCreatePropertyNodeFromDoc)
        {
            _parameters.PropertyBuilders.Add(howToCreatePropertyNodeFromDoc);
            return this;
        }
        public SignDSL NodeToSign(string xpathToNode)
        {
            _parameters.XPathNodeToSign = xpathToNode;
            return this;
        }

        public void SignToFile(string outputPath)
        {
            _parameters.OutputPath = outputPath;
            Signer.From(_parameters).Sign(_parameters);
        }
        public XmlDocument SignAndGetXml()
        {
            return Signer.From(_parameters).SignAndGetXml(_parameters);
        }
    }
}
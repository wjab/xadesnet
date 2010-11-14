using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using XadesNetLib.Common;
using XadesNetLib.XAdES.Common;
using XadesNetLib.XAdES.Signing;

namespace XadesNetLib.XAdES.Dsl
{
    public class XAdESSignDSL
    {
        private readonly XAdESSignParameters _parameters = new XAdESSignParameters();

        public XAdESSignDSL InputPath(string inputPath)
        {
            _parameters.InputPath = inputPath;
            return this;
        }
        public XAdESSignDSL InputXml(XmlDocument xmlDocument)
        {
            _parameters.InputXml = xmlDocument;
            return this;
        }

        public XAdESSignDSL Using(X509Certificate2 certificate)
        {
            _parameters.SignatureCertificate = certificate;
            return this;
        }

        public XAdESSignDSL WithProperty(string propertyName, string propertyValue)
        {
            _parameters.Properties.Add(new XmlPropertyDescriptor
                                           {
                                               Name = propertyName,
                                               Value = propertyValue
                                           });
            return this;
        }
        public XAdESSignDSL WithProperty(string propertyName, string propertyValue, string propertyNameSpace)
        {
            _parameters.Properties.Add(new XmlPropertyDescriptor
            {
                Name = propertyName,
                Value = propertyValue,
                NameSpace = propertyNameSpace
            });
            return this;
        }
        public XAdESSignDSL WithPropertyBuiltFromDoc(Converter<XmlDocument, XmlElement> howToCreatePropertyNodeFromDoc)
        {
            _parameters.PropertyBuilders.Add(howToCreatePropertyNodeFromDoc);
            return this;
        }
        public XAdESSignDSL IncludingCertificateInSignature()
        {
            _parameters.IncludeCertificateInSignature = true;
            return this;
        }
        public XAdESSignDSL DoNotIncludeCertificateInSignature()
        {
            _parameters.IncludeCertificateInSignature = false;
            return this;
        }

        public void SignToFile(string outputPath)
        {
            _parameters.OutputPath = outputPath;
            XAdESSigner.SignToFile(_parameters);
        }
        public XmlDocument SignAndGetXml()
        {
            return XAdESSigner.SignAndGetXml(_parameters);
        }
    }
}
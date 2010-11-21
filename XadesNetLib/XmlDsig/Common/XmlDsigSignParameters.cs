using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using XadesNetLib.Common;

namespace XadesNetLib.XmlDsig.Common
{
    public class XmlDsigSignParameters
    {
        public bool IncludeCertificateInSignature { get; set; }

        public string InputPath { get; set; }
        public XmlDocument InputXml { get; set; }
        public string XPathNodeToSign { get; set; }

        public string OutputPath { get; set; }

        public X509Certificate2 SignatureCertificate { get; set; }
        public XmlDsigSignatureFormat SignatureFormat { get; set; }
        public bool IncludeTimestamp { get; set; }

        private List<XmlPropertyDescriptor> _properties = new List<XmlPropertyDescriptor>();
        public List<XmlPropertyDescriptor> Properties
        {
            get { return _properties; }
            set { _properties = value; }
        }

        private List<Converter<XmlDocument, XmlElement>> _propertyBuilders = new List<Converter<XmlDocument, XmlElement>>();
        public List<Converter<XmlDocument, XmlElement>> PropertyBuilders
        {
            get { return _propertyBuilders; }
            set { _propertyBuilders = value; }
        }

        public override string ToString()
        {
            return "Parameters: " + Environment.NewLine +
                   "\t IncludeCertificateInSignature: " + IncludeCertificateInSignature + Environment.NewLine +
                   "\t InputPath: " + InputPath + Environment.NewLine +
                   "\t InputXml: " + InputXml.OuterXml + Environment.NewLine +
                   "\t XPathNodeToSign: " + XPathNodeToSign + Environment.NewLine +
                   "\t OutputPath: " + OutputPath + Environment.NewLine +
                   "\t SignatureCertificate: " + SignatureCertificate + Environment.NewLine +
                   "\t SignatureFormat: " + SignatureFormat + Environment.NewLine +
                   "\t IncludeTimestamp: " + IncludeTimestamp + Environment.NewLine;
        }
    }
}
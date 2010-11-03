using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace XadesNetLib.XmlDsig
{
    public class XmlDsigSignParameters
    {
        public bool IncludeCertificateInSignature { get; set; }
        
        public string InputPath { get; set; }
        public XmlDocument InputXml { get; set; }

        public string OutputPath { get; set; }

        public X509Certificate2 SignatureCertificate { get; set; }
        public XmlDsigSignatureFormat SignatureFormat { get; set; }
    }
}
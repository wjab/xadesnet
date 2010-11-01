using System.Security.Cryptography.X509Certificates;

namespace XadesNetLib.xmlDsig
{
    public class XmlDsigSignParameters
    {
        public bool IncludeCertificateInSignature { get; set; }
        public string InputPath { get; set; }
        public string OutputPath { get; set; }
        public X509Certificate2 SignatureCertificate { get; set; }
        public XmlDsigSignatureFormat SignatureFormat { get; set; }
        public string OutputSignaturePath { get; set; }
    }
}
using System.Security.Cryptography.X509Certificates;
using System.Xml;

namespace XadesNetLib.XmlDsig.Common
{
    public class VerificationResults
    {
        public string Timestamp { get; set; }
        public XmlDocument OriginalDocument { get; set; }
        public X509Certificate2 SigningCertificate { get; set; }
    }
}
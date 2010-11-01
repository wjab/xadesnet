using System.Security.Cryptography.X509Certificates;

namespace XadesNetLib.xmlDsig
{
    public class XmlDsigValidationParameters
    {
        public string InputPath { get; set; }
        public X509Certificate2 ValidationCertificate { get; set; }
        public bool ValidateCertificate { get; set; }
    }
}

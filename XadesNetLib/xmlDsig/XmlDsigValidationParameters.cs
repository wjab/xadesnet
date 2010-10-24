using System.Security.Cryptography.X509Certificates;

namespace XadesNetLib.xmlDsig
{
    public class XmlDsigValidationParameters
    {
        public string PathDocumento { get; set; }
        public X509Certificate2 CertificadoValidacion { get; set; }
        public bool ValidarTambienElCertificado { get; set; }
    }
}

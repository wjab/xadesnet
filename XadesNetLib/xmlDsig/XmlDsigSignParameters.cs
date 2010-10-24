using System.Xml;
using System.Security.Cryptography.X509Certificates;

namespace XadesNetLib.xmlDsig
{
    public class XmlDsigSignParameters
    {
        public bool IncluirCertificadoEnFirma { get; set; }
        public XmlDocument XmlDeEntrada { get; set; }
        public string PathSalida { get; set; }
        public X509Certificate2 CertificadoDeFirma { get; set; }
        public XmlDsigSignatureFormat FormatoDeFirma { get; set; }
    }
}
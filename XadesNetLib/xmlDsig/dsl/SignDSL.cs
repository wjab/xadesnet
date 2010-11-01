using System.Security.Cryptography.X509Certificates;

namespace XadesNetLib.xmlDsig.dsl
{
    public class SignDSL
    {
        private readonly XmlDsigSignParameters _parameters = new XmlDsigSignParameters();

        public SignDSL InputPath(string inputPath)
        {
            _parameters.InputPath = inputPath;
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
        public SignDSL DetachedIn(string pathOfSignature)
        {
            _parameters.SignatureFormat = XmlDsigSignatureFormat.Detached;
            _parameters.OutputSignaturePath = pathOfSignature;
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

        public void SaveTo(string outputPath)
        {
            _parameters.OutputPath = outputPath;
            XmlDsig.SignDocument(_parameters);
        }
    }
}
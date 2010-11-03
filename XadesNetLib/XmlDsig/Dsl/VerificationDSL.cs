using System.Security.Cryptography.X509Certificates;
using XadesNetLib.XmlDsig.Signing;

namespace XadesNetLib.XmlDsig.Dsl
{
    public class VerificationDSL
    {
        private readonly XmlDsigValidationParameters _parameters = new XmlDsigValidationParameters();

        public VerificationDSL SignaturePath(string signaturePath)
        {
            _parameters.InputPath = signaturePath;
            return this;
        }

        public VerificationDSL Using(X509Certificate2 validationCertificate)
        {
            _parameters.ValidationCertificate = validationCertificate;
            return this;
        }

        public VerificationDSL AlsoVerifyCertificate()
        {
            _parameters.ValidateCertificate = true;
            return this;
        }
        public VerificationDSL DoNotVerifyCertificate()
        {
            _parameters.ValidateCertificate = false;
            return this;
        }

        public void Perform()
        {
            Verifier.Verify(_parameters);
        }
    }
}
using System.Security.Cryptography.X509Certificates;
using XadesNetLib.XmlDsig.Common;
using XadesNetLib.XmlDsig.Operations;

namespace XadesNetLib.XmlDsig.Dsl
{
    public class VerificationDSL
    {
        private readonly XmlDsigVerificationParameters _parameters = new XmlDsigVerificationParameters();

        public VerificationDSL SignaturePath(string signaturePath)
        {
            _parameters.InputPath = signaturePath;
            return this;
        }

        public VerificationDSL Using(X509Certificate2 validationCertificate)
        {
            _parameters.VerificationCertificate = validationCertificate;
            return this;
        }

        public VerificationDSL AlsoVerifyCertificate()
        {
            _parameters.VerifyCertificate = true;
            return this;
        }
        public VerificationDSL DoNotVerifyCertificate()
        {
            _parameters.VerifyCertificate = false;
            return this;
        }

        public void Perform()
        {
            XmlDsigVerifyOperation.Verify(_parameters);
        }

        public VerificationResults PerformAndGetResults()
        {
            return XmlDsigVerifyOperation.VerifyAndGetResults(_parameters);
        }
    }
}
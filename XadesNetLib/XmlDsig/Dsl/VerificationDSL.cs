using System.Security.Cryptography.X509Certificates;
using XadesNetLib.Common;
using XadesNetLib.XmlDsig.Common;
using XadesNetLib.XmlDsig.Operations;

namespace XadesNetLib.XmlDsig.Dsl
{
    public class VerificationDsl
    {
        private readonly VerificationParameters _parameters = new VerificationParameters();

        public VerificationDsl SignaturePath(string signaturePath)
        {
            _parameters.InputPath = signaturePath;
            return this;
        }

        public VerificationDsl Using(X509Certificate2 validationCertificate)
        {
            _parameters.VerificationCertificate = validationCertificate;
            return this;
        }

        public VerificationDsl AlsoVerifyCertificate()
        {
            _parameters.VerifyCertificate = true;
            return this;
        }
        public VerificationDsl DoNotVerifyCertificate()
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
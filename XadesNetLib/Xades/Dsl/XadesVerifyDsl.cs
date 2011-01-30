using XadesNetLib.Common;
using XadesNetLib.Xades.Operations;
using XadesNetLib.XmlDsig.Common;

namespace XadesNetLib.Xades.Dsl
{
    public class XadesVerifyDsl
    {
        private readonly VerificationParameters _parameters = new VerificationParameters();

        public XadesVerifyDsl SignaturePath(string signaturePath)
        {
            _parameters.InputPath = signaturePath;
            return this;
        }

        public XadesVerifyDsl AlsoVerifyCertificate()
        {
            _parameters.VerifyCertificate = true;
            return this;
        }
        public XadesVerifyDsl DoNotVerifyCertificate()
        {
            _parameters.VerifyCertificate = false;
            return this;
        }

        public void Perform()
        {
            XadesVerifyOperation.Verify(_parameters);
        }

        public VerificationResults PerformAndGetResults()
        {
            return XadesVerifyOperation.VerifyAndGetResults(_parameters);
        }
    }
}
using System.Security.Cryptography.X509Certificates;

namespace XadesNetLib.Signatures.Verification
{
    public class VerificationParameters
    {
        public string InputPath { get; set; }
        public X509Certificate2 VerificationCertificate { get; set; }
        public bool VerifyCertificate { get; set; }
    }
}
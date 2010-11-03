using NUnit.Framework;
using XadesNetLib.Certificates;

namespace Testing
{
    [TestFixture]
    public class CertificatesTest
    {
        
        [Test]
        [ExpectedException(typeof(CertificateStoreAccessDeniedException))]
        public void CheckInvalidParamsTest()
        {
            // I know, this is kind of twisted, but there's really bad people
            // out there.
            CertificateUtils.GetCertificatesFrom((CertificateStore) 2);
        }
    }
}

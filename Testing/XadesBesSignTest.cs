using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using NUnit.Framework;
using XadesNetLib.XAdES;

namespace Testing
{
    [TestFixture]
    public class XadesBesSignTest
    {
        #region Common to all tests

        private XmlDocument SignXadesBes(string inputPath, X509Certificate2 selectedCertificate)
        {
            return XadesHelper.Sign(inputPath).Using(selectedCertificate).
                IncludingCertificateInSignature().SignAndGetXml();
        }

        private void ExecuteTest(string inputPath, string resultPath)
        {
            var selectedCertificate = GetTestCertificate();
            var signedDocument = SignXadesBes(inputPath, selectedCertificate);
            var expectedDocument = GetDocumentFromFile(resultPath);

            Assert.AreEqual(signedDocument, expectedDocument);
        }

        private object GetDocumentFromFile(string resultPath)
        {
            if (File.Exists(resultPath))
            {
                return File.ReadAllText(resultPath);
            }
            return string.Empty;
        }

        private X509Certificate2 GetTestCertificate()
        {
            return null;
        }

        #endregion

        #region Test definition
        [Test]
        private void TestSigns()
        {
            ExecuteTest(@"pathEntrada", @"pathresultado");
        }
        #endregion

    }
}

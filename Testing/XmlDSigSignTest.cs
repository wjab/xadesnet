using NUnit.Framework;

using XadesNetLib.XmlDsig;

namespace Testing
{
    [TestFixture]
    public class XmlDSigSignTest
    {
        private const string SimpleSignInFile = "";
        private const string SimpleSignOutFile = "";
        private const string SimpleSignResultFile = "";

        [Test]
        public void TestSimpleSign()
        {
            XmlDsigHelper.Sign(SimpleSignOutFile).Enveloped().InputPath(SimpleSignInFile);

            string expectedResult = TestingHelper.GetFileContents(SimpleSignResultFile);
            string obtainedResult = TestingHelper.GetFileContents(SimpleSignOutFile);
            Assert.AreEqual(expectedResult, obtainedResult);
        }
    }
}

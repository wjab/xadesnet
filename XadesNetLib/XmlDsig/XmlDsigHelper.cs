using XadesNetLib.XmlDsig.Dsl;
using System.Xml;

namespace XadesNetLib.XmlDsig
{
    public abstract class XmlDsigHelper
    {
        public static SignDSL Sign(string inputPath)
        {
            var signDsl = new SignDSL();
            signDsl.InputPath(inputPath);
            return signDsl;
        }
        public static SignDSL Sign(XmlDocument xmlDocument)
        {
            var signDsl = new SignDSL();
            signDsl.InputXml(xmlDocument);
            return signDsl;
        }

        public static VerificationDSL Verify(string signaturePath)
        {
            var validationDsl = new VerificationDSL();
            validationDsl.SignaturePath(signaturePath);
            return validationDsl;
        }
    }
}
using System.Xml;
using XadesNetLib.XAdES.Dsl;

namespace XadesNetLib.XAdES
{
    public class XAdESHelper
    {
        public static XAdESSignDSL Sign(string inputPath)
        {
            var signDsl = new XAdESSignDSL();
            signDsl.InputPath(inputPath);
            return signDsl;
        }
        public static XAdESSignDSL Sign(XmlDocument xmlDocument)
        {
            var signDsl = new XAdESSignDSL();
            signDsl.InputXml(xmlDocument);
            return signDsl;
        }

        //public static XAdESVerificationDSL Verify(string signaturePath)
        //{
        //    var validationDsl = new XAdESVerificationDSL();
        //    validationDsl.SignaturePath(signaturePath);
        //    return validationDsl;
        //}
    }
}
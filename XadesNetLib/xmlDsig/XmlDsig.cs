using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;
using XadesNetLib.xmlDsig.dsl;

namespace XadesNetLib.xmlDsig
{
    public abstract class XmlDsig
    {
        public static SignDSL Sign(string inputPath)
        {
            var signDsl = new SignDSL();
            signDsl.InputPath(inputPath);
            return signDsl;
        }

        public static ValidationDSL Validate(string signaturePath)
        {
            var validationDsl = new ValidationDSL();
            validationDsl.SignaturePath(signaturePath);
            return validationDsl;
        }
    }
}

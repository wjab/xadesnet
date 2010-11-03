using System.Security.Cryptography.Xml;
using System.Xml;
using XadesNetLib.XmlDsig.Exceptions;

namespace XadesNetLib.XmlDsig.Signing.Signers
{
    public class DetachedSigner : Signer
    {
        protected override void CreateAndAddReferenceTo(SignedXml signedXml, XmlDocument document, string inputPath)
        {
            if (signedXml == null)
            {
                throw new InvalidParameterException("Signed Xml cannot be null");
            }
            if (inputPath == null)
            {
                throw new InvalidParameterException("Input path cannot be null");
            }

            var reference = new Reference { Uri = "file://" + inputPath.Replace("\\", "/") };
            signedXml.AddReference(reference);
        }
    }
}
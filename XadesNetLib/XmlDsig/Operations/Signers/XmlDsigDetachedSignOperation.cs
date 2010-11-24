using System.Security.Cryptography.Xml;
using System.Xml;
using XadesNetLib.Exceptions;

namespace XadesNetLib.XmlDsig.Operations.Signers
{
    internal class XmlDsigDetachedSignOperation : XmlDsigSignOperation
    {
        protected override void CreateAndAddReferenceTo(SignedXml signedXml, XmlDocument document, string inputPath, string xpathToNodeToSign)
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
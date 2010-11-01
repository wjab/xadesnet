using System.Security.Cryptography.Xml;
using System.Xml;

namespace XadesNetLib.xmlDsig.signing
{
    public class DetachedSigner : Signer
    {
        protected override void CreateAndAddReferenceTo(SignedXml signedXml, XmlDocument document, string inputPath)
        {
            var reference = new Reference { Uri = "file://" + inputPath.Replace("\\", "/") };
            signedXml.AddReference(reference);
        }
    }
}
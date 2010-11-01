using System.Security.Cryptography.Xml;
using System.Xml;

namespace XadesNetLib.xmlDsig.signing
{
    public class EnvelopingSigner : Signer
    {
        protected override void CreateAndAddReferenceTo(SignedXml signedXml, XmlDocument document, string inputPath)
        {
            var signatureReference = new Reference("#documentdata");
            signatureReference.AddTransform(new XmlDsigExcC14NTransform());
            signedXml.AddReference(signatureReference);
            var dataObject = new DataObject("documentdata", "", "", document.DocumentElement);
            signedXml.AddObject(dataObject);
        }
        protected override void AddCanonicalizationMethodTo(SignedXml signedXml)
        {
            signedXml.SignedInfo.CanonicalizationMethod = SignedXml.XmlDsigExcC14NTransformUrl;
        }
    }
}
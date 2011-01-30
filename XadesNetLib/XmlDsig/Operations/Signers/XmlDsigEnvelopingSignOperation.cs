 using System.Security.Cryptography.Xml;
using System.Xml;
 using XadesNetLib.Common.Exceptions;

namespace XadesNetLib.XmlDsig.Operations.Signers
{
    internal class XmlDsigEnvelopingSignOperation : XmlDsigSignOperation
    {
        protected override void CreateAndAddReferenceTo(SignedXml signedXml, XmlDocument document, string inputPath, string xpathToNodeToSign)
        {
            if (signedXml == null)
            {
                throw new InvalidParameterException("Signed Xml cannot be null");
            }
            if (document == null)
            {
                throw new InvalidParameterException("Xml document cannot be null");
            }
            if (document.DocumentElement == null)
            {
                throw new InvalidParameterException("Xml document must have root element");
            }

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
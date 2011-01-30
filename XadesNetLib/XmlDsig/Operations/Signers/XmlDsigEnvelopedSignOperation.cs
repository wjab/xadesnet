using System.Security.Cryptography.Xml;
using System.Xml;
using XadesNetLib.Common.Exceptions;

namespace XadesNetLib.XmlDsig.Operations.Signers
{
    internal class XmlDsigEnvelopedSignOperation : XmlDsigSignOperation
    {
        protected override void CreateAndAddReferenceTo(SignedXml signedXml, XmlDocument document, string inputPath, string xpathToNodeToSign)
        {
            if (signedXml == null)
            {
                throw new InvalidParameterException("Signed Xml cannot be null");
            }

            if (xpathToNodeToSign == null) xpathToNodeToSign = "";
            var signatureReference = new Reference { Uri = xpathToNodeToSign};
            signatureReference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            signedXml.AddReference(signatureReference);
        }
        protected override XmlDocument BuildFinalSignedXmlDocument(XmlDocument inputXml, XmlElement signatureXml)
        {
            var raiz = inputXml.DocumentElement;
            if (raiz != null) raiz.AppendChild(inputXml.ImportNode(signatureXml, true));
            return inputXml;
        }
    }
}
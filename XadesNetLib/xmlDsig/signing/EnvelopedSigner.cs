using System.Security.Cryptography.Xml;
using System.Xml;

namespace XadesNetLib.xmlDsig.signing
{
    public class EnvelopedSigner : Signer
    {
        protected override void CreateAndAddReferenceTo(SignedXml signedXml, XmlDocument document, string inputPath)
        {
            var signatureReference = new Reference { Uri = "" };
            signatureReference.AddTransform(new XmlDsigEnvelopedSignatureTransform());
            signedXml.AddReference(signatureReference);
        }
        protected override void SaveSignatureToFile(XmlDocument xmlAFirmar, XmlElement signatureXml,
            XmlDsigSignParameters signParameters)
        {
            var raiz = xmlAFirmar.DocumentElement;
            if (raiz != null) raiz.AppendChild(xmlAFirmar.ImportNode(signatureXml, true));
            xmlAFirmar.Save(signParameters.OutputPath);
        }
    }
}
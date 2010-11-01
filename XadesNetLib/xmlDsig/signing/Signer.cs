using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography.Xml;
using System.Xml;

namespace XadesNetLib.xmlDsig.signing
{
    public abstract class Signer
    {
        public static Signer From(XmlDsigSignParameters parameters)
        {
            switch (parameters.SignatureFormat)
            {
                case XmlDsigSignatureFormat.Enveloping:
                    return new EnvelopingSigner();
                case XmlDsigSignatureFormat.Enveloped:
                    return new EnvelopedSigner();
                case XmlDsigSignatureFormat.Detached:
                    return new DetachedSigner();
            }
            throw new Exception("There isn't a '" + parameters.SignatureFormat + "' signer implemented");
        }

        public void Sign(XmlDsigSignParameters signParameters)
        {
            ValidateParameters(signParameters);

            var xmlAFirmar = new XmlDocument();
            xmlAFirmar.Load(signParameters.InputPath);

            var signature = GetSignature(xmlAFirmar, signParameters.SignatureCertificate, signParameters.InputPath);
            SaveSignatureToFile(xmlAFirmar, signature.GetXml(), signParameters);
        }
        #region Métodos de implementación de los pasos de firma

        private static void ValidateParameters(XmlDsigSignParameters signParameters)
        {
            if (signParameters == null) throw new InvalidParameterException("Parameters to sign cannot be null");
            if (signParameters.SignatureCertificate == null) throw new InvalidParameterException("Signer Certificate cannot be null");
            if (signParameters.InputPath == null) throw new InvalidParameterException("Document to sign cannot be null");
            if (signParameters.OutputPath == null) throw new InvalidParameterException("Path of signed file cannot be null");
        }
        private SignedXml GetSignature(XmlDocument document, X509Certificate2 certificate, string inputPath)
        {
            if (document.DocumentElement == null) throw new InvalidDocumentException("Document to sign has no root element");

            var signedXml = new SignedXml(document);
            CreateAndAddReferenceTo(signedXml, document, inputPath);
            IncludeSignatureCertificate(signedXml, certificate);
            AddCanonicalizationMethodTo(signedXml);
            signedXml.ComputeSignature();

            return signedXml;
        }
        protected virtual void AddCanonicalizationMethodTo(SignedXml signedXml)
        {
        }
        protected void IncludeSignatureCertificate(SignedXml signedXml, X509Certificate2 certificate)
        {
            signedXml.SigningKey = certificate.PrivateKey;

            var certificateKeyInfo = new KeyInfo();
            certificateKeyInfo.AddClause(new KeyInfoX509Data(certificate));
            signedXml.KeyInfo = certificateKeyInfo;
        }
        protected virtual void SaveSignatureToFile(XmlDocument xmlAFirmar, XmlElement signatureXml, XmlDsigSignParameters signParameters)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(signatureXml.OuterXml);
            xmlDocument.Save(signParameters.OutputPath);
        }

        #endregion



        #region Métodos a sobreescribir

        protected abstract void CreateAndAddReferenceTo(SignedXml signedXml, XmlDocument document, string inputPath);

        #endregion
    }
}
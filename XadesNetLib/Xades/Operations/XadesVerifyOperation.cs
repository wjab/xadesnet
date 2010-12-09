using System;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml;
using XadesNetLib.Cryptography;
using XadesNetLib.Exceptions;
using XadesNetLib.Signatures.Verification;
using XadesNetLib.Utils;
using XadesNetLib.XmlDsig.Common;
using XadesNetLib.XmlDsig.Operations;
using XadesNetLib.Xml;

namespace XadesNetLib.Xades.Operations
{
    class XadesVerifyOperation
    {
        public static void Verify(VerificationParameters parameters)
        {
            var result = XmlDsigVerifyOperation.VerifyAndGetResults(parameters);
            VerifySigningCertificate(parameters, result.SigningCertificate);
        }

        private static void VerifySigningCertificate(VerificationParameters parameters, X509Certificate2 signingCertificate)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(parameters.InputPath);
            var nodoDeCertificado = XmlHelper.FindNodesIn(xmlDocument.DocumentElement, 
                "Signature/KeyInfo/X509Data/X509Certificate");
            var nodoDeSigningCertificate = XmlHelper.FindNodesIn(xmlDocument.DocumentElement,
                "Signature/Object/QualifyingProperties/SignedProperties/" + 
                "SignedSignatureProperties/SigningCertificate/Cert/CertDigest");
            var certificateBase64 = signingCertificate.RawData;
            var certificateHashNode = XmlHelper.FindNodesIn(nodoDeSigningCertificate[0], 
                "DigestValue");
            var certificateHashInSignature = Convert.FromBase64String(certificateHashNode[0].InnerText);
            var calculatedHash = CryptoHelper.GetBytesSHA1(certificateBase64);
            if (!ArrayHelper.ArraysAreEqual(certificateHashInSignature, calculatedHash))
            {
                throw new InvalidSignedDocumentException("SigningCertificate cannot be verified");
            }

        }

        public static VerificationResults VerifyAndGetResults(VerificationParameters parameters)
        {
            var result = XmlDsigVerifyOperation.VerifyAndGetResults(parameters);
            VerifySigningCertificate(parameters, result.SigningCertificate);
            return result;
        }
    }
}
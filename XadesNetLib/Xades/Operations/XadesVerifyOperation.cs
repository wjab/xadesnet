using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using XadesNetLib.Common;
using XadesNetLib.Common.Exceptions;
using XadesNetLib.Utils;
using XadesNetLib.Utils.Cryptography;
using XadesNetLib.Utils.Xml;
using XadesNetLib.XmlDsig.Common;
using XadesNetLib.XmlDsig.Operations;

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
            var certificateBase64 = signingCertificate.RawData;
            var calculatedHash = CryptoHelper.GetBytesSHA1(certificateBase64);

            var xmlDocument = new XmlDocument();
            xmlDocument.Load(parameters.InputPath);
            var signingCertificateNode = XmlHelper.FindNodesIn(xmlDocument.DocumentElement,
                "Signature/Object/QualifyingProperties/SignedProperties/" + 
                "SignedSignatureProperties/SigningCertificate/Cert/CertDigest");
            var certificateHashNode = XmlHelper.FindNodesIn(signingCertificateNode[0], 
                "DigestValue");
            var certificateHashInSignature = Convert.FromBase64String(certificateHashNode[0].InnerText);
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
using System.Security.Cryptography.X509Certificates;
using XadesNetLib.xmlDsig.signing;

namespace XadesNetLib.xmlDsig.dsl
{
    public class ValidationDSL
    {
        private readonly XmlDsigValidationParameters _parameters = new XmlDsigValidationParameters();

        public ValidationDSL SignaturePath(string signaturePath)
        {
            _parameters.InputPath = signaturePath;
            return this;
        }

        public ValidationDSL Using(X509Certificate2 validationCertificate)
        {
            _parameters.ValidationCertificate = validationCertificate;
            return this;
        }

        public ValidationDSL DetachedDocumentIn(string pathToDocument)
        {
            _parameters.PathToDocument = pathToDocument;
            return this;
        }

        public ValidationDSL AlsoValidateCertificate()
        {
            _parameters.ValidateCertificate = true;
            return this;
        }
        public ValidationDSL DoNotValidateCertificate()
        {
            _parameters.ValidateCertificate = false;
            return this;
        }

        public void Perform()
        {
            Validator.Validate(_parameters);
        }
    }
}
using System;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using XadesNetLib.Common.Exceptions;
using XadesNetLib.Utils;
using XadesNetLib.XmlDsig.Common;
using System.Collections.Generic;

namespace XadesNetLib.XmlDsig.Dsl
{
    public class BatchSignDSL
    {
        private string[] _inputPaths;
        private SignDSL _signDsl;
        private XmlDocument[] _inputXmls;
        private string[] _outputPaths;

        public void InputPaths(string[] inputPaths)
        {
            _inputPaths = inputPaths;
            _inputXmls = new XmlDocument[] { };
            _signDsl = new SignDSL();
        }
        public void InputXmls(XmlDocument[] inputXmls)
        {
            _inputXmls = inputXmls;
            _inputPaths = new string[] { };
            _signDsl = new SignDSL();
        }
        public BatchSignDSL Using(X509Certificate2 certificate)
        {
            _signDsl.Using(certificate);
            return this;
        }
        public BatchSignDSL UsingFormat(XmlDsigSignatureFormat format)
        {
            _signDsl.UsingFormat(format);
            return this;
        }
        public BatchSignDSL IncludingCertificateInSignature()
        {
            _signDsl.IncludingCertificateInSignature();
            return this;
        }
        public BatchSignDSL Enveloping()
        {
            _signDsl.Enveloping();
            return this;
        }
        public BatchSignDSL Enveloped()
        {
            _signDsl.Enveloped();
            return this;
        }
        public BatchSignDSL Detached()
        {
            _signDsl.Detached();
            return this;
        }
        public BatchSignDSL DoNotIncludeCertificateInSignature()
        {
            _signDsl.DoNotIncludeCertificateInSignature();
            return this;
        }
        public BatchSignDSL IncludeTimestamp(bool includeTimestamp)
        {
            _signDsl.IncludeTimestamp(includeTimestamp);
            return this;
        }
        public BatchSignDSL WithProperty(string propertyName, string propertyValue)
        {
            _signDsl.WithProperty(propertyName, propertyValue);
            return this;
        }
        public BatchSignDSL WithProperty(string propertyName, string propertyValue, string propertyNameSpace)
        {
            _signDsl.WithProperty(propertyName, propertyValue, propertyNameSpace);
            return this;
        }
        public BatchSignDSL WithPropertyBuiltFromDoc(Converter<XmlDocument, XmlElement> howToCreatePropertyNodeFromDoc)
        {
            _signDsl.WithPropertyBuiltFromDoc(howToCreatePropertyNodeFromDoc);
            return this;
        }
        public void SignToFiles(params string[] outputPaths)
        {
            _outputPaths = outputPaths;
            if (!CheckInputOutputIntegrity())
                throw new InvalidParameterException("Check input and output paths!");

            if (_inputPaths.Length > 0)
            {
                for (var i = 0; i < _outputPaths.Length; i++)
                {
                    _signDsl.InputPath(_inputPaths[i]);
                    _signDsl.SignToFile(_outputPaths[i]);
                }
                return;
            }
            for (var i = 0; i < _outputPaths.Length; i++)
            {
                _signDsl.InputXml(_inputXmls[i]);
                _signDsl.SignToFile(_outputPaths[i]);
            }
        }

        private bool CheckInputOutputIntegrity()
        {
            return ArrayHelper.ArrayHasSameLengthAsAny(_outputPaths, _inputXmls, _inputPaths);
        }

        public XmlDocument[] SignAndGetXmls()
        {
            var result = new List<XmlDocument>();
            ArrayHelper.DoWithFirstNotEmpty(item =>
                                           {
                                               if (item is string)
                                               {
                                                   _signDsl.InputPath((string) item);
                                               }
                                               else
                                               {
                                                   _signDsl.InputXml((XmlDocument) item);
                                               }
                                               result.Add(_signDsl.SignAndGetXml());
                                           }, _inputPaths, _inputXmls);
            return result.ToArray();
        }
    }
}
using System.Runtime.Serialization;
using System;

namespace XadesNetLib.XmlDsig
{
    [Serializable]
    class InvalidDocumentException : Exception
    {
        public InvalidDocumentException()
        {
        }

        public InvalidDocumentException(string message)
            : base(message)
        {
        }

        public InvalidDocumentException(string message,
      Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidDocumentException(SerializationInfo info,
      StreamingContext context)
            : base(info, context)
        {
        }
    }
}

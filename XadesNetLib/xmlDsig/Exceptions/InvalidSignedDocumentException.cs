using System;
using System.Runtime.Serialization;

namespace XadesNetLib.xmlDsig
{
    [Serializable]
    public class InvalidSignedDocumentException: Exception
    {
         public InvalidSignedDocumentException()
        {
        }

        public InvalidSignedDocumentException(string message)
            : base(message)
        {
        }

        public InvalidSignedDocumentException(string message,
      Exception innerException)
            : base(message, innerException)
        {
        }

        protected InvalidSignedDocumentException(SerializationInfo info,
      StreamingContext context)
            : base(info, context)
        {
        }
    }
}
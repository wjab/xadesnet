using System;

namespace XadesNetLib.XmlDsig.Exceptions
{
    public class InvalidSignedDocumentException: Exception
    {
        public InvalidSignedDocumentException(string message): base(message)
        {
        }
    }
}
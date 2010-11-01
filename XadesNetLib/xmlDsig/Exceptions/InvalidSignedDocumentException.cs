using System;

namespace XadesNetLib.xmlDsig
{
    public class InvalidSignedDocumentException: Exception
    {
        public InvalidSignedDocumentException(string message): base(message)
        {
        }
    }
}
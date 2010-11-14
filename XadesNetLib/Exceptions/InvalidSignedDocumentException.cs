using System;

namespace XadesNetLib.Exceptions
{
    public class InvalidSignedDocumentException: Exception
    {
        public InvalidSignedDocumentException(string message): base(message)
        {
        }
    }
}
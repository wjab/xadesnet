using System;

namespace XadesNetLib.Common.Exceptions
{
    public class InvalidSignedDocumentException: Exception
    {
        public InvalidSignedDocumentException(string message): base(message)
        {
        }
    }
}
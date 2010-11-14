using System.Security.Cryptography;
using System.Text;
using System;

namespace XadesNetLib.Cryptography
{
    public class CryptoHelper
    {
        private CryptoHelper()
        {
        }

        public static string GetBase64SHA1(string inputString)
        {
            var inputBytes = Encoding.Default.GetBytes(inputString.ToCharArray());
            return GetBytesSHA1(inputBytes);
        }
        public static string GetBytesSHA1(byte[] inputBytes)
        {
            SHA1 cryptoServiceProvider = new SHA1CryptoServiceProvider();
            var outputBytes = cryptoServiceProvider.ComputeHash(inputBytes);
            return Convert.ToBase64String(outputBytes);
        }
    }
}
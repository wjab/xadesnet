using System.Security.Cryptography;
using System.Text;
using System;

namespace XadesNetLib.Utils.Cryptography
{
    public class CryptoHelper
    {
        private CryptoHelper()
        {
        }

        public static string GetBase64SHA1(string inputString)
        {
            var inputBytes = Encoding.Default.GetBytes(inputString.ToCharArray());
            return GetBase64SHA1(inputBytes);
        }
        public static string GetBase64SHA1(byte[] inputBytes)
        {
            byte[] outputBytes = GetBytesSHA1(inputBytes);
            return Convert.ToBase64String(outputBytes);
        }
        public static byte[] GetBytesSHA1(byte[] inputBytes)
        {
            SHA1 cryptoServiceProvider = new SHA1CryptoServiceProvider();
            return cryptoServiceProvider.ComputeHash(inputBytes);
        }
        public static byte[] GetBytesSHA1(string inputString)
        {
            var inputBytes = Encoding.Default.GetBytes(inputString.ToCharArray());
            return GetBytesSHA1(inputBytes);
        }
    }
}
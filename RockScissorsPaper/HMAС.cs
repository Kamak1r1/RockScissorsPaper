using System;
using System.Security.Cryptography;
using System.Text;

namespace RockScissorsPaper
{
    internal class HMAС
    {
        private static short size = 256;

        private static byte[] secretKey = new byte[size / 8];

        private static RandomNumberGenerator generator = new RNGCryptoServiceProvider();

        private static string Convert(byte[] toConvert)
        {
            return BitConverter.ToString(toConvert).Replace("-", string.Empty);
        }

        internal static string GenerateHMAC(string str)
        {
            generator.GetBytes(secretKey);
            HMAC pcHMAC = new HMACSHA256(secretKey);
            var pcHASH = pcHMAC.ComputeHash(Encoding.Default.GetBytes(str));
            Console.WriteLine($"\nHMAC: {Convert(pcHASH)}");
            return Convert(pcHMAC.Key);
        }

        internal static void ShowKey(string key)
        {
            Console.WriteLine($"Key: {key}");
        }
    }
}

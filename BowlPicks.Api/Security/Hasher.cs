using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;

namespace BowlPicks.Api.Security
{
    public class Hasher
    {
        private const int SaltValueSize = 8;

        public static byte[] GenerateSaltValue()
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[SaltValueSize];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return buff;
        }

        public static byte[] HashPassword(byte[] plainText, byte[] salt)
        {
            HashAlgorithm algorithm = new SHA256Managed();

            byte[] plainTextWithSaltBytes =
              new byte[plainText.Length + salt.Length];

            for (int i = 0; i < plainText.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainText[i];
            }
            for (int i = 0; i < salt.Length; i++)
            {
                plainTextWithSaltBytes[plainText.Length + i] = salt[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);  
        }
    }
}
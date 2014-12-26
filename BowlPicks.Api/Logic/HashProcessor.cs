using System.Security.Cryptography;

namespace BowlPicks.Api.Logic
{
    public interface IHashProcessor
    {
        byte[] HashPassword(byte[] plainText, byte[] salt);
        byte[] GenerateSaltValue();
    }
    public class HashProcessor : IHashProcessor
    {
        private const int SaltValueSize = 8;

        public byte[] HashPassword(byte[] plainText, byte[] salt)
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

        public byte[] GenerateSaltValue()
        {
            //Generate a cryptographic random number.
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            byte[] buff = new byte[SaltValueSize];
            rng.GetBytes(buff);

            // Return a Base64 string representation of the random number.
            return buff;
        }
    }
}
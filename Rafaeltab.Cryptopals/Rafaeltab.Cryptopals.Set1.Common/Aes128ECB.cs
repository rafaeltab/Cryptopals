using System.Security.Cryptography;

namespace Rafaeltab.Cryptopals.Set1.Common
{
    public static class Aes128ECB
    {
        public static byte[] Encrypt(byte[] data, byte[] key) {
            using (var aes = new AesManaged
            {
                Mode = CipherMode.ECB,
                KeySize = 128,
                Key = key,
                Padding = PaddingMode.ISO10126
            })
            {
                var encryptor = aes.CreateEncryptor();
                var encrypted = encryptor.TransformFinalBlock(data, 0, data.Length);

                return encrypted;
            }
        }
        public static byte[] Decrypt(byte[] data, byte[] key)
        {
            using (var aes = new AesManaged
            {
                Mode = CipherMode.ECB,
                KeySize = 128,
                Key = key,
                Padding = PaddingMode.ISO10126 
            })
            {
                var decryptor = aes.CreateDecryptor();
                var decrypted = decryptor.TransformFinalBlock(data, 0, data.Length);

                return decrypted;
            }
        }
    }
}

using System.Security.Cryptography;
using System.Text;
using System;

namespace Inventory.AppCode.Helper
{
    public static class EncryptionHelper
    {
        private const string EncryptionKey = "YourEncryptionKey"; // Replace with your encryption key

        public static string Encrypt(string plainText)
        {
            byte[] plainBytes = Encoding.UTF8.GetBytes(plainText);
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
            aesAlg.IV = aesAlg.Key.Take(16).ToArray();

            using MemoryStream msEncrypt = new();
            using (CryptoStream csEncrypt = new(msEncrypt, aesAlg.CreateEncryptor(), CryptoStreamMode.Write))
            {
                csEncrypt.Write(plainBytes, 0, plainBytes.Length);
                csEncrypt.FlushFinalBlock();
                byte[] cipherBytes = msEncrypt.ToArray();
                return Convert.ToBase64String(cipherBytes);
            }
        }

        public static string Decrypt(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = Encoding.UTF8.GetBytes(EncryptionKey);
            aesAlg.IV = aesAlg.Key.Take(16).ToArray();

            using MemoryStream msDecrypt = new();
            using (CryptoStream csDecrypt = new(msDecrypt, aesAlg.CreateDecryptor(), CryptoStreamMode.Write))
            {
                csDecrypt.Write(cipherBytes, 0, cipherBytes.Length);
                csDecrypt.FlushFinalBlock();
                byte[] plainBytes = msDecrypt.ToArray();
                return Encoding.UTF8.GetString(plainBytes, 0, plainBytes.Length);
            }
        }
    }
    
}

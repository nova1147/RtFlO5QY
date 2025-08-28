// 代码生成时间: 2025-08-29 05:14:42
using System;
using System.Security.Cryptography;
using System.Text;

namespace PasswordEncryptionDecryption
{
    public class PasswordEncryptionDecryptionTool
    {
        // Specifies the secret key to be used for encryption and decryption.
        private readonly byte[] _secretKey = Encoding.UTF8.GetBytes("your_secret_key_here");
        private readonly byte[] _iv = Encoding.UTF8.GetBytes("your_initialization_vector_here");
        
        // Encrypts a password using AES encryption.
        public string EncryptPassword(string password)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = _secretKey;
                    aesAlg.IV = _iv;

                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                    using (var msEncrypt = new MemoryStream())
                    {
                        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                        {
                            using (var swEncrypt = new StreamWriter(csEncrypt))
                            {
                                swEncrypt.Write(password);
                            }
                        }

                        byte[] passwordBytes = msEncrypt.ToArray();
                        return Convert.ToBase64String(passwordBytes);
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any encryption errors.
                throw new CryptographicException("Encryption failed", ex);
            }
        }

        // Decrypts a password using AES decryption.
        public string DecryptPassword(string encryptedPassword)
        {
            try
            {
                using (Aes aesAlg = Aes.Create())
                {
                    aesAlg.Key = _secretKey;
                    aesAlg.IV = _iv;

                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                    using (var msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedPassword)))
                    {
                        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                        {
                            using (var srDecrypt = new StreamReader(csDecrypt))
                            {
                                return srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle any decryption errors.
                throw new CryptographicException("Decryption failed", ex);
            }
        }
    }
}

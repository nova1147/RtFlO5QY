// 代码生成时间: 2025-08-26 12:19:44
using System;
using System.Security.Cryptography;
using System.Text;

namespace HashingTools
{
    /// <summary>
    /// A utility class for calculating hash values.
    /// </summary>
    public class HashCalculator
    {
        /// <summary>
        /// Computes the SHA256 hash of the provided string.
        /// </summary>
        /// <param name="input">The string to be hashed.</param>
        /// <returns>The SHA256 hash of the input string.</returns>
        public string ComputeSHA256Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("=>", "").ToLowerInvariant();
            }
        }

        /// <summary>
        /// Computes the MD5 hash of the provided string.
        /// </summary>
        /// <param name="input">The string to be hashed.</param>
        /// <returns>The MD5 hash of the input string.</returns>
        public string ComputeMD5Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string cannot be null or empty.", nameof(input));
            }

            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                return BitConverter.ToString(hashBytes).Replace("=>", "").ToLowerInvariant();
            }
        }

        // Additional hash algorithms can be added here following the same pattern.
    }
}

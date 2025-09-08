// 代码生成时间: 2025-09-08 14:45:29
using System;
using System.Security.Cryptography;
using System.Text;

namespace HashValueCalculatorApp
{
    /// <summary>
    /// A utility class to calculate hash values for strings.
    /// </summary>
    public class HashValueCalculator
    {
        /// <summary>
        /// Calculates the SHA256 hash value of the provided string.
        /// </summary>
        /// <param name="input">The input string to hash.</param>
        /// <returns>The SHA256 hash value as a hexadecimal string.</returns>
        public static string CalculateSHA256Hash(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be null or whitespace.", nameof(input));
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
            }
        }

        /// <summary>
        /// Calculates the MD5 hash value of the provided string.
        /// </summary>
        /// <param name="input">The input string to hash.</param>
        /// <returns>The MD5 hash value as a hexadecimal string.</returns>
        public static string CalculateMD5Hash(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentException("Input cannot be null or whitespace.", nameof(input));
            }

            using (MD5 md5 = MD5.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = md5.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", string.Empty).ToLowerInvariant();
            }
        }
    }
}

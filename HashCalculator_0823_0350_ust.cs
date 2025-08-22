// 代码生成时间: 2025-08-23 03:50:49
using System;
using System.Security.Cryptography;
using System.Text;

namespace HashCalculator
{
    /// <summary>
    /// A utility class to calculate hash values of strings.
    /// </summary>
    public class HashCalculator
    {
        /// <summary>
        /// Calculates the SHA256 hash of a given string.
        /// </summary>
        /// <param name="input">The string to hash.</param>
        /// <returns>The SHA256 hash of the input string.</returns>
        public static string CalculateSHA256Hash(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentException("Input string is null or empty.", nameof(input));
            }

            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hash = sha256.ComputeHash(bytes);
# FIXME: 处理边界情况

                // Convert the byte array to a hexadecimal string.
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    builder.Append(hash[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }

    public class Program
    {
        /// <summary>
        /// Main entry point of the application.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
# 添加错误处理
        public static void Main(string[] args)
        {
            try
            {
                // Example usage: Calculate hash of a string.
                string inputString = "Hello, World!";
                string hash = HashCalculator.CalculateSHA256Hash(inputString);
# 添加错误处理
                Console.WriteLine($"The SHA256 hash of '{inputString}' is: {hash}");
            }
            catch (Exception ex)
            {
                // Error handling.
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
# 增强安全性
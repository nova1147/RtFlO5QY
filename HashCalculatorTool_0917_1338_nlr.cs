// 代码生成时间: 2025-09-17 13:38:52
using System;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// A tool for calculating hash values of strings.
/// </summary>
public class HashCalculatorTool
{
    /// <summary>
    /// Calculates the MD5 hash of a given string.
    /// </summary>
    /// <param name="input">The string to be hashed.</param>
    /// <returns>The MD5 hash of the input string.</returns>
    public static string CalculateMD5Hash(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input cannot be null or empty.", nameof(input));
        }

        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }

    /// <summary>
    /// Calculates the SHA256 hash of a given string.
    /// </summary>
    /// <param name="input">The string to be hashed.</param>
    /// <returns>The SHA256 hash of the input string.</returns>
    public static string CalculateSHA256Hash(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            throw new ArgumentException("Input cannot be null or empty.", nameof(input));
        }

        using (SHA256 sha256 = SHA256.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = sha256.ComputeHash(inputBytes);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < hashBytes.Length; i++)
            {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}

// 代码生成时间: 2025-08-29 18:51:41
using System;
using System.Web;

namespace RandomNumberGeneratorApp
{
    /// <summary>
    /// Provides functionality to generate random numbers in an ASP.NET application.
    /// </summary>
    public class RandomNumberGenerator
    {
        private readonly Random _random;

        /// <summary>
        /// Initializes a new instance of the RandomNumberGenerator class.
        /// </summary>
        public RandomNumberGenerator()
        {
            _random = new Random();
        }

        /// <summary>
        /// Generates a random integer within a specified range.
        /// </summary>
        /// <param name="min">The minimum value of the range.</param>
        /// <param name="max">The maximum value of the range.</param>
        /// <returns>A random integer between min and max (inclusive).</returns>
        public int GenerateRandomNumber(int min, int max)
        {
            if (min > max)
            {
                throw new ArgumentException("The minimum value cannot be greater than the maximum value.");
            }

            return _random.Next(min, max + 1);
        }
    }

    /// <summary>
    /// The main class for the ASP.NET application which uses the RandomNumberGenerator.
    /// </summary>
    public class Program
    {
        static void Main()
        {
            try
            {
                RandomNumberGenerator rng = new RandomNumberGenerator();
                int randomNumber = rng.GenerateRandomNumber(1, 100);
                Console.WriteLine($"Generated Random Number: {randomNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
// 代码生成时间: 2025-09-10 06:51:41
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAnalysis
{
    public class DataStatisticsAnalyzer
    {
        // Method to calculate the average of a list of numbers
        public double CalculateAverage(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("The list of numbers cannot be null or empty.");
            }

            double sum = numbers.Sum();
            return sum / numbers.Count;
        }

        // Method to calculate the median of a list of numbers
        public double CalculateMedian(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("The list of numbers cannot be null or empty.");
            }

            numbers = new List<double>(numbers); // Create a copy to avoid modifying the original list
            numbers.Sort();
            int middleIndex = numbers.Count / 2;
            
            if (numbers.Count % 2 == 0)
            {
                // Even number of elements, return average of two middle numbers
                return (numbers[middleIndex - 1] + numbers[middleIndex]) / 2.0;
            }
            else
            {
                // Odd number of elements, return the middle number
                return numbers[middleIndex];
            }
        }

        // Method to calculate the standard deviation of a list of numbers
        public double CalculateStandardDeviation(List<double> numbers)
        {
            if (numbers == null || numbers.Count == 0)
            {
                throw new ArgumentException("The list of numbers cannot be null or empty.");
            }

            double mean = CalculateAverage(numbers);
            double sumOfSquares = numbers.Sum(x => Math.Pow(x - mean, 2));
            return Math.Sqrt(sumOfSquares / numbers.Count);
        }
    }
}

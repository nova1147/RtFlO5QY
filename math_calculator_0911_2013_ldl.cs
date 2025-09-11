// 代码生成时间: 2025-09-11 20:13:20
using System;

namespace MathTools
{
    public class MathCalculator
    {
        // Adds two numbers
        public double Add(double a, double b)
        {
            return a + b;
        }

        // Subtracts second number from the first number
        public double Subtract(double a, double b)
        {
            return a - b;
        }

        // Multiplies two numbers
        public double Multiply(double a, double b)
        {
            return a * b;
        }

        // Divides first number by the second number
        // Throws DivideByZeroException if b is zero
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero.");
            }
            return a / b;
        }

        // Calculates the square of a number
        public double Square(double a)
        {
            return Math.Pow(a, 2);
        }

        // Calculates the square root of a number
        // Throws ArgumentOutOfRangeException if a is negative
        public double Sqrt(double a)
        {
            if (a < 0)
            {
                throw new ArgumentOutOfRangeException("a", "Cannot calculate the square root of a negative number.");
            }
            return Math.Sqrt(a);
        }
    }
}

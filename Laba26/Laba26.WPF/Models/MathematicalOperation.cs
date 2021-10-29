using System;
using System.Linq;

namespace Laba26.WPF.Models
{
    public static class MathematicalOperation
    {
        /// <summary>
        /// This method is the sum of one number from another (digit1 + digit2 ... + digitN)
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static int Sum(params int[] digits)
        {
            return digits.Sum(d => d);
        }

        /// <summary>
        /// This method is the sum of one number from another (digit1 + digit2 ... + digitN)
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static float Sum(params float[] digits)
        {
            return digits.Sum(d => d);
        }

        /// <summary>
        /// This method is the sum of one number from another (digit1 + digit2 ... + digitN)
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static decimal Sum(params decimal[] digits)
        {
            return digits.Sum(d => d);
        }

        /// <summary>
        /// This method is the sum of one number from another (digit1 + digit2 ... + digitN)
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static double Sum(params double[] digits)
        {
            return digits.Sum(d => d);
        }

        /// <summary>
        /// This method is the subtraction of one number from another
        /// </summary>
        /// <param name="digit1"></param>
        /// <param name="digit2"></param>
        /// <returns></returns>
        public static int Subtraction(int digit1, int digit2)
        {
            return digit1 - digit2;
        }

        /// <summary>
        /// This method is the subtraction of one number from another
        /// </summary>
        /// <param name="digit1"></param>
        /// <param name="digit2"></param>
        /// <returns></returns>
        public static float Subtraction(float digit1, float digit2)
        {
            return digit1 - digit2;
        }

        /// <summary>
        /// This method is the subtraction of one number from another
        /// </summary>
        /// <param name="digit1"></param>
        /// <param name="digit2"></param>
        /// <returns></returns>
        public static decimal Subtraction(decimal digit1, decimal digit2)
        {
            return digit1 - digit2;
        }

        /// <summary>
        /// This method is the subtraction of one number from another
        /// </summary>
        /// <param name="digit1"></param>
        /// <param name="digit2"></param>
        /// <returns></returns>
        public static double Subtraction(double digit1, double digit2)
        {
            return digit1 - digit2;
        }

        /// <summary>
        /// This method is the multiply of one number from another (digit1 * digit2 ... * digitN)
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static int Multiply(params int[] digits)
        {
            return digits.Aggregate((current, digit) => current * digit);
        }

        /// <summary>
        /// This method is the multiply of one number from another (digit1 * digit2 ... * digitN)
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static float Multiply(params float[] digits)
        {
            return digits.Aggregate((current, digit) => current * digit);
        }

        /// <summary>
        /// This method is the multiply of one number from another (digit1 * digit2 ... * digitN)
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static decimal Multiply(params decimal[] digits)
        {
            return digits.Aggregate((current, digit) => current * digit);
        }

        /// <summary>
        /// This method is the multiply of one number from another (digit1 * digit2 ... * digitN)
        /// </summary>
        /// <param name="digits"></param>
        /// <returns></returns>
        public static double Multiply(params double[] digits)
        {
            return digits.Aggregate((current, digit) => current * digit);
        }

        /// <summary>
        /// This method is the divide of one number from another (digit1 / digit2)
        /// </summary>
        /// <param name="digit1"></param>
        /// <param name="digit2"></param>
        /// <returns></returns>
        public static int Divide(int digit1, int digit2)
        {
            if (digit2 == 0)
                throw new DivideByZeroException();

            return digit1 / digit2;
        }

        /// <summary>
        /// This method is the divide of one number from another (digit1 / digit2)
        /// </summary>
        /// <param name="digit1"></param>
        /// <param name="digit2"></param>
        /// <returns></returns>
        public static float Divide(float digit1, float digit2)
        {
            if (digit2 == 0)
                throw new DivideByZeroException();

            return digit1 / digit2;
        }

        /// <summary>
        /// This method is the divide of one number from another (digit1 / digit2)
        /// </summary>
        /// <param name="digit1"></param>
        /// <param name="digit2"></param>
        /// <returns></returns>
        public static decimal Divide(decimal digit1, decimal digit2)
        {
            if (digit2 == 0)
                throw new DivideByZeroException();

            return digit1 / digit2;
        }

        /// <summary>
        /// This method is the divide of one number from another (digit1 / digit2)
        /// </summary>
        /// <param name="digit1"></param>
        /// <param name="digit2"></param>
        /// <returns></returns>
        public static double Divide(double digit1, double digit2)
        {
            if (digit2 == 0)
                throw new DivideByZeroException();

            return digit1 / digit2;
        }
    }
}
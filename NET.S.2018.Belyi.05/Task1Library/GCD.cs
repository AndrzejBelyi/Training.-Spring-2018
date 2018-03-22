using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1Library
{
    public static class GCD
    {
        #region EuclidRealization
        /// <summary>
        /// Finds and returns the greatest common divisor of two integers using the Euclidean algorithm
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>Returns greater common divisor</returns>
        public static int GetGCDByEuclid(int firstNumber, int secondNumber)
        {
            firstNumber = Math.Abs(firstNumber);
            secondNumber = Math.Abs(secondNumber);
            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0)
            {
                return firstNumber;
            }

            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }

            if (firstNumber == 1 || secondNumber == 1)
            {
                return 1;
            }

            return GetGCDByEuclid(secondNumber, firstNumber % secondNumber);
        }

        /// <summary>
        /// Finds and returns the greatest common divisor of three integers using the Euclidean algorithm
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="thirdNumber"></param>
        /// <returns>Returns greater common divisor</returns>
        public static int GetGCDByEuclid(int firstNumber, int secondNumber, int thirdNumber)
        {
           return GetGCDByEuclid(GetGCDByEuclid(firstNumber, secondNumber), thirdNumber);
        }

        /// <summary>
        /// Finds and returns the greatest common divisor of n integers using the Euclidean algorithm
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns>Returns greater common divisor</returns>
        public static int GetGCDByEuclid(params int[] arguments)
        {
            DataVerification(arguments);
            int gcd = GetGCDByEuclid(arguments[0], arguments[1]);
            for (int i = 2; i < arguments.Length; i++)
            {
                gcd = GetGCDByEuclid(gcd, arguments[i]);
            }

            return gcd;
        }
        #endregion EuclidRealization
        #region SteinRealization
        /// <summary>
        /// Finds and returns the greatest common divisor of 2 integers using the Stein algorithm
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <returns>Returns greater common divisor</returns>
        public static int GetGCDByStein(int firstNumber, int secondNumber)
        {
            firstNumber = Math.Abs(firstNumber);
            secondNumber = Math.Abs(secondNumber);
            if (firstNumber == 0)
            {
                return secondNumber;
            }

            if (secondNumber == 0)
            {
                return firstNumber;
            }

            if (firstNumber == secondNumber)
            {
                return firstNumber;
            }

            if (firstNumber == 1 || secondNumber == 1)
            {
                return 1;
            }

            if (firstNumber % 2 == 0 && secondNumber % 2 == 0)
            {
                return 2 * GetGCDByStein(firstNumber / 2, secondNumber / 2);
            }

            if (firstNumber % 2 == 0)
            {
                return GetGCDByStein(firstNumber / 2, secondNumber);
            }

            if (secondNumber % 2 == 0)
            {
                return GetGCDByStein(firstNumber, secondNumber / 2);
            }

            if (firstNumber > secondNumber)
            {
                return GetGCDByStein((firstNumber - secondNumber) / 2, secondNumber);
            }
            else
            {
                return GetGCDByStein((secondNumber - firstNumber) / 2, firstNumber);
            }
        }

        /// <summary>
        /// Finds and returns the greatest common divisor of 3 integers using the Stein algorithm
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="thirdNumber"></param>
        /// <returns>Returns greater common divisor</returns>
        public static int GetGCDByStein(int firstNumber, int secondNumber, int thirdNumber)
        {
           return GetGCDByStein(GetGCDByStein(firstNumber, secondNumber), thirdNumber);
        }

        /// <summary>
        /// Finds and returns the greatest common divisor of n integers using the Stein algorithm
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns>Returns greater common divisor</returns>
        public static int GetGCDByStein(params int[] arguments)
        {
            DataVerification(arguments);
            int gcd = GetGCDByEuclid(arguments[0], arguments[1]);
            for (int i = 2; i < arguments.Length; i++)
            {
                gcd = GetGCDByEuclid(gcd, arguments[i]);
            }

            return gcd;
        }

        /// <summary>
        /// Validating arguments
        /// </summary>
        /// <param name="arguments"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArithmeticException"></exception>
        private static void DataVerification(int[] arguments)
        {            
            if (arguments == null)
            {
               throw new ArgumentNullException();
            }

            if (arguments.Length < 2)
            {
                throw new ArgumentException();
            }
        }
    }
    #endregion SteinRealization
}

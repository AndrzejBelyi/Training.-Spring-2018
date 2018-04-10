using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class GCD
    {    
        /// <summary>
        /// Finds and returns the greatest common divisor of three integers using the Euclidean algorithm
        /// </summary>
        /// <param name="firstNumber"></param>
        /// <param name="secondNumber"></param>
        /// <param name="thirdNumber"></param>
        /// <returns>Returns greater common divisor</returns>
        public static int GetGCDByEuclid(int firstNumber, int secondNumber, int thirdNumber)
        {
            Func<int, int, int> algorithmGCD = GetGCDByEuclid;
            return algorithmGCD(algorithmGCD(firstNumber, secondNumber), thirdNumber);
        }

        /// <summary>
        /// Finds and returns the greatest common divisor of n integers using the Euclidean algorithm
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns>Returns greater common divisor</returns>
        public static int GetGCDByEuclid(params int[] arguments)
        {
            Func<int, int, int> algorithmGCD = GetGCDByEuclid;
            return GetGCD(algorithmGCD, arguments);

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
            Func<int, int, int> algorithmGCD = GetGCDByStein;
            return algorithmGCD(algorithmGCD(firstNumber, secondNumber), thirdNumber);
        }

        /// <summary>
        /// Finds and returns the greatest common divisor of n integers using the Stein algorithm
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns>Returns greater common divisor</returns>
        public static int GetGCDByStein(params int[] arguments)
        {
            Func<int, int, int> algorithmGCD = GetGCDByStein;
            return GetGCD(algorithmGCD,arguments);
        }

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
        /// Gets the GCD.
        /// </summary>
        /// <param name="algorithmGCD">The algorithm GCD.</param>
        /// <param name="parametrs">The parametrs.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">parametrs</exception>
        /// <exception cref="ArgumentException">parametrs</exception>
        private static int GetGCD(Func<int, int, int> algorithmGCD, params int[] parametrs)
        {
            if (parametrs == null)
            {
                throw new ArgumentNullException(nameof(parametrs));
            }

            if (parametrs.Length < 2)
            {
                throw new ArgumentException(nameof(parametrs));
            }

            int result = parametrs[0];
            for (int i = 1; i < parametrs.Length; i++)
            {
                result = algorithmGCD(result, parametrs[i]);
            }
            return result;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public delegate int AlgorithmGcdDelegate(int value1, int value2);

    public static class GCD
    {    

        public static int GetGCD(AlgorithmGcdDelegate algorithmGcd, int firstNumber, int secondNumber)
        {
            return algorithmGcd(firstNumber, secondNumber);
        }

        public static int GetGCD(AlgorithmGcdDelegate algorithmGcd, int firstNumber, int secondNumber, int thirdNumber)
        {
            return algorithmGcd(algorithmGcd(firstNumber, secondNumber), thirdNumber);
        }

        public static int GetGCD(AlgorithmGcdDelegate algorithmGcd, params int[] arguments)
        {
            DataVerification(arguments);
            int gcd = algorithmGcd(arguments[0], arguments[1]);
            for (int i = 2; i < arguments.Length; i++)
            {
                gcd = algorithmGcd(gcd, arguments[i]);
            }

            return gcd;
        }

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
}

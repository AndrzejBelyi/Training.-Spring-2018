using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLibrary
{
    /// <summary>
    /// Class have some methods to filter,find,insert 
    /// </summary>
    public class Algorithms
    {
        /// <summary>
        /// InsertNumber algorithm for inserting bits of one number into another
        /// </summary>
        /// <param name="firstNumber">Number to input</param>
        /// <param name="secondNumber">Number as source</param>
        /// <param name="firstIndex">index to copy "From"</param>
        /// <param name="lastIndex">index to copy "To"</param>
        /// <returns>Returns integer after insert</returns>
        public static int InsertNumber(int firstNumber, int secondNumber, int firstIndex, int lastIndex)
        {
            if (firstIndex > lastIndex)
            {
                throw new ArgumentException();
            }

            if (firstIndex > 32)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (firstIndex > 32)
            {
                throw new ArgumentOutOfRangeException();
            }

            int[] firstNumberArray = GetBinaryArrayFromInt(firstNumber);
            int[] secondNumberArray = GetBinaryArrayFromInt(secondNumber);
            int size = lastIndex - firstIndex + 1;
            int[] temp = secondNumberArray.Skip(secondNumberArray.Length - size).ToArray();
            int m = 0;
            Array.Reverse(firstNumberArray);
            Array.Reverse(temp);
            for (int i = firstIndex; i <= lastIndex; i++)
            {
                firstNumberArray[i] = temp[m++];
            }

            Array.Reverse(firstNumberArray);
            return GetIntByBinaryArray(firstNumberArray);
        }

        /// <summary>
        /// Method find and returns next integer number which 
        /// consists of the same numbers
        /// </summary>
        /// <param name="number">Number to find next number</param>
        /// <returns>Next bigger number which 
        /// consists of the same numbers</returns>
        /// <exception cref="ArgumentException">works only with numbers >0 </exception>
        public static int FindNextBiggerNumber(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException();
            }

            int[] digitArray = GetDigitsOfNumber(number);
            int i, j;
            int n = digitArray.Length;
            for (i = n - 1; i > 0; i--)
            {
                if (digitArray[i] > digitArray[i - 1])
                {
                    break;
                }
            }

            if (i == 0)
            {
                return -1;
            }

            int x = digitArray[i - 1], min = i;
            for (j = i + 1; j < n; j++)
            {
                if (digitArray[j] > x && digitArray[j] < digitArray[min])
                {
                    min = j;
                }
            }

            Swap(digitArray, i - 1, min);
            Array.Reverse(digitArray, i, n - i);
            return GetIntNumberFromDigitsArray(digitArray);
        }

        /// <summary>
        /// This method returns an array of numbers that contain a given digit
        /// </summary>
        /// <param name="array">Array for filtration</param>
        /// <param name="targetDigit">digit for filtration</param>
        /// <returns>Filtered array</returns>        
        public static int[] FilterDigit(int[] array, int targetDigit)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (targetDigit > 9 || targetDigit < 0)
            {
                throw new ArgumentException();
            }
            else
            {
                List<int> filtredArray = new List<int>();
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i].ToString().Contains(targetDigit.ToString()))
                    {
                        filtredArray.Add(array[i]);
                    }
                }

                return filtredArray.ToArray();
            }
        }

        public static ArrayList FilterDigit0(int[] listInts, int number)
        {
            if (listInts.Length == 0)
            {
                throw new ArgumentException();
            }

            ArrayList listFilter = new ArrayList();
            for (int i = 0; i < listInts.Length; i++)
            {
                string supportString = listInts[i].ToString();
                string numberString = number.ToString();
                if (supportString.Contains(numberString))
                {
                    listFilter.Add(listInts[i]);
                }
            }

            return listFilter;
        }

        public static int[] FilterDigit1(int[] numbers, int digit)
        {
            if ((digit < 0) || (digit > 9))
            {
                throw new ArgumentException($"{nameof(digit)} must be from 0 to 9", nameof(digit));
            }

            if (numbers == null)
            {
                throw new ArgumentException(nameof(numbers));
            }

            if (numbers.Length == 0)
            {
                return null;
            }

            int[] result = new int[0];
            string digitStr = digit.ToString();
            for (int i = 0; i < numbers.Length; i++)
            {
                string number = numbers[i].ToString();
                if (number.Contains(digitStr))
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = numbers[i];
                }
            }

            return result;
        }

        public static int[] FilterDigit2(int[] numbers, int digit)
        {
            if ((digit < 0) || (digit > 9))
            {
                throw new ArgumentException($" {nameof(digit)} must be from 0 to 9", nameof(digit));
            }

            if (numbers == null)
            {
                throw new ArgumentException(nameof(numbers));
            }

            if (numbers.Length == 0)
            {
                return null;
            }

            List<int> result = new List<int>();
            string digitStr = digit.ToString();
            for (int i = 0; i < numbers.Length; i++)
            {
                string number = numbers[i].ToString();
                if (number.Contains(digitStr))
                {
                    result.Add(numbers[i]);
                }
            }

            return result.ToArray();
        }

        public static int[] FilterDigit3(int[] numbers, int digit)
        {
            if ((digit < 0) || (digit > 9))
            {
                throw new ArgumentException($"{nameof(digit)} must be from 0 to 9", nameof(digit));
            }

            if (numbers == null)
            {
                throw new ArgumentException(nameof(numbers));
            }

            if (numbers.Length == 0)
            {
                throw new ArgumentException(nameof(numbers));
            }

            List<int> result = new List<int>();
            foreach (var element in numbers)
            {
                if (IsContainsDigit(element, digit))
                {
                    result.Add(element);
                }
            }

            return result.ToArray();
        }

        /// <summary>
        /// The method returns an integer consisting of an incoming array of elements
        /// </summary>
        /// <param name="digitsArray">Array which consists a digits</param>
        /// <returns>integer consisting of an incoming array of elements</returns>
        private static int GetIntNumberFromDigitsArray(int[] digitsArray)
        {
            int number = 0, multiplier = 1;
            for (int i = digitsArray.Length - 1; i >= 0; i--)
            {
                number += multiplier * digitsArray[i];
                multiplier *= 10;
            }

            return number;
        }

        /// <summary>
        /// Method returns array of digits which contains a number
        /// </summary>
        /// <param name="number">Number to get digits</param>
        /// <returns>Array which consist digits of number</returns>
        private static int[] GetDigitsOfNumber(int number)
        {
            List<int> digitsList = new List<int>();
            while (number > 0)
            {
                digitsList.Add(number % 10);

                number /= 10;
            }

            digitsList.Reverse();
            return digitsList.ToArray();
        }

        /// <summary>
        /// Method used to swap to elements in array 
        /// </summary>
        /// <param name="array">Array to replacement </param>
        /// <param name="i">Index of first element</param>
        /// <param name="j">Index of second element</param>
        private static void Swap(int[] array, int i, int j)
        {
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        /// <summary>
        /// Checking if number contains digit
        /// </summary>
        /// <param name="number">Number to search</param>
        /// <param name="digit">Digit for search in number</param>
        /// <returns>true if contains,else - false</returns>
        private static bool IsContainsDigit(int number, int digit)
        {
            while (number != 0)
            {
                if (number % 10 == digit)
                {
                    return true;
                }

                number = number / 10;
            }

            return false;
        }

        /// <summary>
        /// Returns a number in the binary representation as an array
        /// </summary>
        /// <param name="number"></param>
        /// <returns>array</returns>
        private static int[] GetBinaryArrayFromInt(int number)
        {
            string binaryNumber = Convert.ToString(number, 2).PadLeft(32, '0');
            int[] binaryNumberArray = new int[32];
            for (int i = 0; i < binaryNumberArray.Length; i++)
            {
                binaryNumberArray[i] = (int)char.GetNumericValue(binaryNumber[i]);
            }

            return binaryNumberArray;
        }

        /// <summary>
        /// Returns a number in the decimal number system getting a binary array
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int GetIntByBinaryArray(int[] array)
        {
            string result = string.Join(string.Empty, array);
            return Convert.ToInt32(result, 2);
        }
    }
}

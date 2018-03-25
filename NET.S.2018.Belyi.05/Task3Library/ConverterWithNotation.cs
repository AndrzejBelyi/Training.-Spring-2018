using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Library
{
  public static class ConverterWithNotation
    {
        /// <summary>
        /// Method converts number to decimal numeral system
        /// </summary>
        /// <param name="number"></param>
        /// <param name="notation"></param>
        /// <returns>returns integer</returns>
        public static int ToDec(this string number, Notation notation)
        {
            if (String.IsNullOrEmpty(number))
            {
                throw new ArgumentNullException(nameof(number));
            }

            if (!notation.IsValidNumber(number))
            {
                throw new ArgumentException(nameof(number));
            }

            int result = 0;
            for (int i = 0; i < number.Length; i++)
            {                
                int x = 0;
                if (number[i] < '0' || number[i] > '9')
                {
                    x = char.ToUpper(number[i]) - 'A' + 10;
                }
                else
                {
                    x = number[i] - '0';
                } 
                
                result = result * notation.NotationBase + x;
            }

            return result;
        }
    }
}

using System.Collections.Generic;
using System.Numerics;

namespace Task1
{
    public class FibonacciGenerator
    {
        /// <summary>
        /// Generates the specified count.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <returns></returns>
        public static IEnumerable<BigInteger> Generate(int count)
        {
            BigInteger prev = -1;
            BigInteger next = 1;
            for (int i = 1; i < count; i++)
            {
                BigInteger sum = prev + next;
                prev = next;
                next = sum;
                yield return sum;
            }
        }
    }
}

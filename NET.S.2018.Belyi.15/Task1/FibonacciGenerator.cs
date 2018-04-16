using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace Task1
{
    public class FibonacciGenerator
    {
        public static IEnumerable<BigInteger> Generate(uint count)
        {
            BigInteger prev = 1;
            BigInteger next = 1;
            for (uint i = 1; i < count; i++)
            {
                BigInteger sum = prev + next;
                prev = next;
                next = sum;
                yield return sum;
            }
        }
    }
}

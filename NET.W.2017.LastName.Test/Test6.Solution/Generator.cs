using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test6.Solution
{
    public static class Generator
    {
        public static IEnumerable<T> Generate<T>(T first, T second, uint length, Func<T, T, T> getNext)
        {
            if (ReferenceEquals(getNext, null))
            {
                throw new ArgumentNullException(nameof(getNext));
            }

            return GenerateSequence(first, second, length, getNext);
        }

        private static IEnumerable<T> GenerateSequence<T>(T first, T second, ulong length, Func<T,T,T> getNext)
        {
            yield return first;
            yield return second;

            for(ulong i = 2ul; i < length; i++)
            {
                T next = getNext(first,second);
                first = second;
                second = next;
                yield return next;               
            }
        }
    }
}

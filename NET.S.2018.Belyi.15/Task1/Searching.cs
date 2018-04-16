using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
   public static class Searching
    {
        /// <summary>
        /// Tries the binary search.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="collection">The collection.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// item
        /// or
        /// collection
        /// </exception>
        public static int BinarySearch<T>(this IEnumerable<T> collection, T item)
        where T : IComparable<T>
        {
            CheckInput(item, collection);

            int index;
            if (TryBinarySearch(collection, item, Comparer<T>.Default, out index))
            {
                return index;
            }

            return -1;
        }

        /// <summary>
        /// Binaries the search.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="collection">The collection.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// item
        /// or
        /// collection
        /// or
        /// item
        /// </exception>
        public static int BinarySearch<T>(this IEnumerable<T> collection, T item, IComparer<T> comparer)
        {
            CheckInput(item, collection);
            if (ReferenceEquals(comparer, null))
            {
                throw new ArgumentNullException($"{nameof(item)} is null!");
            }

            int index;
            if (TryBinarySearch(collection, item, comparer, out index))
            {
                return index;
            }

            return -1;
        }

        /// <summary>
        /// Binaries the search.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="collection">The collection.</param>
        /// <param name="comparison">The comparison.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">item</exception>
        public static int BinarySearch<T>(this IEnumerable<T> collection, T item, Comparison<T> comparison)
        {
            CheckInput(item, collection);
            if (ReferenceEquals(comparison, null))
            {
                throw new ArgumentNullException($"{nameof(item)} is null!");
            }

            int index;
            if (TryBinarySearch(collection, item, Comparer<T>.Create(comparison), out index))
            {
                return index;
            }

            return -1;
        }

        /// <summary>
        /// Tries the binary search.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="collection">The collection.</param>
        /// <param name="comparer">The comparer.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        private static bool TryBinarySearch<T>(this IEnumerable<T> collection, T item, IComparer<T> comparer, out int index)
        {
            index = 0;
            int left = 0;
            int right = collection.Count();
            int mid = 0;

            while (!(left >= right))
            {
                mid = left + ((right - left) / 2);
                if (comparer.Compare(collection.ElementAt(mid), item) == 0)
                {
                    index = mid;
                    return true;
                }

                if (comparer.Compare(collection.ElementAt(mid), item) > 0)
                {
                    right = mid;
                }
                else
                {
                    left = mid + 1;
                }
            }

            return false;
        }

        /// <summary>
        /// Checks the input.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item">The item.</param>
        /// <param name="collection">The collection.</param>
        /// <exception cref="System.ArgumentNullException">
        /// item
        /// or
        /// collection
        /// </exception>
        private static void CheckInput<T>(T item, IEnumerable<T> collection)
        {
            if (ReferenceEquals(item, null))
            {
                throw new ArgumentNullException($"{nameof(item)} is null!");
            }

            if (ReferenceEquals(collection, null))
            {
                throw new ArgumentNullException($"{nameof(collection)} is null!");
            }
        }
    }
}

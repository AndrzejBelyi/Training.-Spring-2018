using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public static class Filters
    {
        /// <summary>
        /// Filters the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, IPredicate<T> predicate)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            if (predicate == null)
            {
                throw new ArgumentNullException();
            }

            return Filter(predicate.Predicate, collection);
        }

        /// <summary>
        /// Filters the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="collection">The collection.</param>
        /// <param name="predicate">The predicate.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// </exception>
        public static IEnumerable<T> Filter<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            if (predicate == null)
            {
                throw new ArgumentNullException();
            }

            return Filter(predicate, collection);
        }

        /// <summary>
        /// Filters the specified predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate">The predicate.</param>
        /// <param name="collection">The collection.</param>
        /// <returns></returns>
        private static IEnumerable<T> Filter<T>(Predicate<T> predicate, IEnumerable<T> collection)
        {
            Collection<T> filtredArray = new Collection<T>();
            for (int i = 0; i < collection.Count(); i++)
            {
                if (predicate(collection.ElementAt(i)))
                {
                    filtredArray.Add(collection.ElementAt(i));
                }
            }

            return filtredArray;
        }
    }
}

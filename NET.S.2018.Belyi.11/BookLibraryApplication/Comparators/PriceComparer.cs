using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace BookLibraryApplication.Comparators
{
    public class PriceComparer : IComparer<Book>
    {
        /// <summary>
        /// Compares the specified first book.
        /// </summary>
        /// <param name="firstBook">The first book.</param>
        /// <param name="secondBook">The second book.</param>
        /// <returns></returns>
        public int Compare(Book firstBook, Book secondBook)
        {
            if (ReferenceEquals(firstBook, secondBook))
            {
                return 0;
            }
            else
            {
                return (int)(firstBook.Price - secondBook.Price);
            }
        }
    }
}

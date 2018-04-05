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

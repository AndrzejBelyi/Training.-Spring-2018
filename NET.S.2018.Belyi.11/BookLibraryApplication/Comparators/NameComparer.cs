using System;
using System.Collections.Generic;
using BookLibrary;

namespace BookLibraryApplication.Comparators
{
    public class NameComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if (ReferenceEquals(x, y))
            {
                return 0;
            }

            return string.Compare(x.Title, y.Title, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}

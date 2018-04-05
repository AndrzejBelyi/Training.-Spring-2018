using BookLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryApplication.Comparators
{
    public class NameComparer : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            if(ReferenceEquals(x,y))
            {
                return 0;
            }
            return string.Compare(x.Title, y.Title, StringComparison.InvariantCultureIgnoreCase);
        }
    }
}

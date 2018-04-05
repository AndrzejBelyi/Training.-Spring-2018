using BookLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryApplication.Tags
{
    class TitlePredicate : IBookPredicate<Book>
    {
        string title;

        public TitlePredicate(string title)
        {
            if (ReferenceEquals(title, null))
            {
                throw new ArgumentNullException($"{nameof(title)} is null");
            }
            this.title = title;
        }
        public bool IsAcceptable(Book book)
        {
            return string.Equals(this.title,book.Author) ? true : false;    
        }
    }
}

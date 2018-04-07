using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookLibrary;

namespace BookLibraryApplication.Tags
{
    public class TitlePredicate : IBookPredicate<Book>
    {
        /// <summary>
        /// The title
        /// </summary>
        private string title;

        /// <summary>
        /// Initializes a new instance of the <see cref="TitlePredicate"/> class.
        /// </summary>
        /// <param name="title">The title.</param>
        /// <exception cref="ArgumentNullException">title</exception>
        public TitlePredicate(string title)
        {
            if (ReferenceEquals(title, null))
            {
                throw new ArgumentNullException($"{nameof(title)} is null");
            }

            this.title = title;
        }

        /// <summary>
        /// Determines whether the specified book is acceptable.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>
        /// <c>true</c> if the specified book is acceptable; otherwise, <c>false</c>.
        /// </returns>
        public bool IsAcceptable(Book book)
        {
            return string.Equals(this.title, book.Author) ? true : false;    
        }
    }
}

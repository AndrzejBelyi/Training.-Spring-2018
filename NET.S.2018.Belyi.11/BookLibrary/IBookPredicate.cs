using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public interface IBookPredicate<Book>
    {
        /// <summary>
        /// Determines whether the specified book is acceptable.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <returns>
        ///   <c>true</c> if the specified book is acceptable; otherwise, <c>false</c>.
        /// </returns>
        bool IsAcceptable(Book book);
    }
}

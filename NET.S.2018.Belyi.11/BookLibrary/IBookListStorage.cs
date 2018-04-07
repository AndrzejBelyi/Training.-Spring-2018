using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public interface IBookListStorage
    {
        /// <summary>
        /// Saves to storage.
        /// </summary>
        /// <param name="books">The books.</param>
        void SaveToStorage(List<Book> books);

        /// <summary>
        /// Loads from storage.
        /// </summary>
        /// <returns></returns>
        List<Book> LoadFromStorage();
    }
}

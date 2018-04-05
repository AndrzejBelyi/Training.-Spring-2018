using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public interface IBookListStorage
    {
        void SaveToStorage(List<Book> books);

        List<Book> LoadFromStorage();
    }
}

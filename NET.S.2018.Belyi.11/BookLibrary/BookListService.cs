using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;
namespace BookLibrary
{

    public sealed class BookListService
    {
        public List<Book> bookList { get; private set; }
        ILogger Logger { get; }

        public BookListService(ILogger logger = null)
        {
            if (ReferenceEquals(logger, null))
            {
                Logger = new NLogger();
            }
            else
            {
                Logger = logger;
            }

            bookList = new List<Book>();
        }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                Logger.Error($"{nameof(book)} is null");
                throw new ArgumentNullException($"{nameof(book)} is null");
            }

            if (bookList.Contains(book))
            {
                Logger.Error($"{nameof(book)} is already exist!");
                throw new ArgumentException($"{nameof(book)} is already exist!");
            }

            bookList.Add(book);
            Logger.Info($"{nameof(book)} added!");
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                Logger.Error($"{nameof(book)} is null!");
                throw new ArgumentNullException($"{nameof(book)} is null");
            }

            if (!bookList.Remove(book))
            {
                Logger.Error($"{nameof(book)} not exist!");
                throw new ArgumentException($"{nameof(book)} is not exist!");
            }
            Logger.Info($"{nameof(book)} remove complete!");
        }

        public void SaveToStorage(IBookListStorage storage)
        {
            Logger.Info($"Saving to storage started!");
            if (ReferenceEquals(storage, null))
            {
                Logger.Error($"{nameof(storage)} is null!");
                throw new ArgumentNullException($"{nameof(storage)} is null");
            }

            storage.SaveToStorage(bookList);
            Logger.Info($"Saving to storage completed!");
        }

        public void LoadFromStorage(IBookListStorage storage)
        {
            Logger.Info($"Loading from storage!");
            if (ReferenceEquals(storage, null))
            {
                throw new ArgumentNullException($"{nameof(storage)} is null");
            }

            bookList = storage.LoadFromStorage();
            Logger.Info($"Loading from storage completed!");
        }

        public void SortBooksListByTag(IComparer<Book> comparer)
        {
            Logger.Info($"Sorting!");
            if (ReferenceEquals(comparer, null))
            {
                Logger.Error($"{nameof(comparer)} is null!");
                throw new ArgumentNullException($"{nameof(comparer)} is null");
            }
            Logger.Info($"Sorting complete!");
            bookList.Sort(comparer);
        }

        public Book FindBookByTag(IBookPredicate<Book> criterion)
        {
            Logger.Info($"Searching...!");
            if (ReferenceEquals(criterion, null))
            {
                Logger.Error($"{nameof(criterion)} is null!");
                throw new ArgumentNullException($"{nameof(criterion)} is null");
            }

            foreach(Book book in bookList)
            {
                if(criterion.IsAcceptable(book))
                {
                    Logger.Info($"Finded!");
                    return book;
                }
            }
            Logger.Warning($"NOT FINDED!");
            return bookList[0];
        }
    }
}

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

            BookList = new List<Book>();
        }

        public List<Book> BookList { get; private set; }

        private ILogger Logger { get; }

        public void AddBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                Logger.Error($"{nameof(book)} is null");
                throw new ArgumentNullException($"{nameof(book)} is null");
            }

            if (BookList.Contains(book))
            {
                Logger.Error($"{nameof(book)} is already exist!");
                throw new ArgumentException($"{nameof(book)} is already exist!");
            }

            BookList.Add(book);
            Logger.Info($"{nameof(book)} added!");
        }

        public void RemoveBook(Book book)
        {
            if (ReferenceEquals(book, null))
            {
                Logger.Error($"{nameof(book)} is null!");
                throw new ArgumentNullException($"{nameof(book)} is null");
            }

            if (!BookList.Remove(book))
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

            storage.SaveToStorage(BookList);
            Logger.Info($"Saving to storage completed!");
        }

        public void LoadFromStorage(IBookListStorage storage)
        {
            Logger.Info($"Loading from storage!");
            if (ReferenceEquals(storage, null))
            {
                throw new ArgumentNullException($"{nameof(storage)} is null");
            }

            BookList = storage.LoadFromStorage();
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
            BookList.Sort(comparer);
        }

        public Book FindBookByTag(IBookPredicate<Book> criterion)
        {
            Logger.Info($"Searching...!");
            if (ReferenceEquals(criterion, null))
            {
                Logger.Error($"{nameof(criterion)} is null!");
                throw new ArgumentNullException($"{nameof(criterion)} is null");
            }

            foreach (Book book in BookList)
            {
                if (criterion.IsAcceptable(book))
                {
                    Logger.Info($"Finded!");
                    return book;
                }
            }

            Logger.Warning($"NOT FINDED!");
            return BookList[0];
        }
    }
}

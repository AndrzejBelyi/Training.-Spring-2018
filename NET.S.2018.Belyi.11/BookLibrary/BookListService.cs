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
        /// <summary>
        /// Initializes a new instance of the <see cref="BookListService"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
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

        /// <summary>
        /// Gets the book list.
        /// </summary>
        /// <value>
        /// The book list.
        /// </value>
        public List<Book> BookList { get; private set; }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        private ILogger Logger { get; }

        /// <summary>
        /// Adds the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <exception cref="ArgumentNullException">book</exception>
        /// <exception cref="ArgumentException">book</exception>
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

        /// <summary>
        /// Removes the book.
        /// </summary>
        /// <param name="book">The book.</param>
        /// <exception cref="ArgumentNullException">book</exception>
        /// <exception cref="ArgumentException">book</exception>
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

        /// <summary>
        /// Saves to storage.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <exception cref="ArgumentNullException">storage</exception>
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

        /// <summary>
        /// Loads from storage.
        /// </summary>
        /// <param name="storage">The storage.</param>
        /// <exception cref="ArgumentNullException">storage</exception>
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

        /// <summary>
        /// Sorts the books list by tag.
        /// </summary>
        /// <param name="comparer">The comparer.</param>
        /// <exception cref="ArgumentNullException">comparer</exception>
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

        /// <summary>
        /// Finds the book by tag.
        /// </summary>
        /// <param name="criterion">The criterion.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">criterion</exception>
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

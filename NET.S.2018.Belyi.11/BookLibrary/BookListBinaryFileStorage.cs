using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logger;

namespace BookLibrary
{
    public sealed class BookListBinaryFileStorage : IBookListStorage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BookListBinaryFileStorage"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="logger">The logger.</param>
        /// <exception cref="ArgumentNullException">path</exception>
        public BookListBinaryFileStorage(string path, ILogger logger = null)
        { 
            if (ReferenceEquals(logger, null))
            {
                Logger = new NLogger(); 
            }
            else
            {
                Logger = logger;
            }

            if (string.IsNullOrWhiteSpace(path))
            {
                Logger.Error($"{nameof(path)} is null or empty");
                throw new ArgumentNullException($"{nameof(path)} is null or empty");
            }

            Path = path;
        }
        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>
        /// The path.
        /// </value>
        private string Path { get; }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        /// <value>
        /// The logger.
        /// </value>
        private ILogger Logger { get; }

        /// <summary>
        /// Saves to storage.
        /// </summary>
        /// <param name="books">The books.</param>
        /// <exception cref="ArgumentNullException">books</exception>
        /// <exception cref="ArgumentException">books</exception>
        public void SaveToStorage(List<Book> books)
        {
            if (ReferenceEquals(books, null))
            {
                Logger.Error($"{nameof(books)} is null");
                throw new ArgumentNullException($"{nameof(books)} is null");
            }

            if (books.Count == 0)
            {
                Logger.Error($"{nameof(books)} is null");
                throw new ArgumentException($"{nameof(books)} is empty");
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(Path, FileMode.Create)))
            {
                Logger.Info($"Saving started");
                for (int i = 0; i < books.Count; i++)
                {
                    writer.Write(books[i].ISBN);
                    writer.Write(books[i].Title);
                    writer.Write(books[i].Author);
                    writer.Write(books[i].Publisher);
                    writer.Write(books[i].PublishingYear);
                    writer.Write(books[i].NumberOfPages);
                    writer.Write(books[i].Price);
                }

                Logger.Info($"Saving complete");
            }
        }

        /// <summary>
        /// Loads from storage.
        /// </summary>
        /// <returns></returns>
        public List<Book> LoadFromStorage()
        {
            Logger.Info($"Load started");
            List<Book> booksList = new List<Book>();

            using (BinaryReader reader = new BinaryReader(File.Open(Path, FileMode.Open)))
            {
                while (reader.PeekChar() > -1)
                {
                    booksList.Add(new Book(
                        reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadString(), reader.ReadInt32(), reader.ReadDecimal()));
                }
            }

            Logger.Info($"Load complete");
            return booksList;
        }
    }
}

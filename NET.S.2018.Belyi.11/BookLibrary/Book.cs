using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public sealed class Book : IComparable<Book>, IComparable, IEquatable<Book>, IFormattable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Book"/> class.
        /// </summary>
        /// <param name="isbn">The isbn.</param>
        /// <param name="title">The title.</param>
        /// <param name="author">The author.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="publishingYear">The publishing year.</param>
        /// <param name="numberOfPages">The number of pages.</param>
        /// <param name="price">The price.</param>
        public Book(string isbn, string title, string author, string publisher, string publishingYear, int numberOfPages, decimal price)
        {
            CheckInputData(isbn, title, author, publisher, publishingYear, numberOfPages, price);
            ISBN = isbn;
            Title = title;
            Author = author;
            Publisher = publisher;
            PublishingYear = publishingYear;
            NumberOfPages = numberOfPages;
            Price = price;
        }

        /// <summary>
        /// Gets the isbn.
        /// </summary>
        /// <value>
        /// The isbn.
        /// </value>
        public string ISBN { get; }

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; }

        /// <summary>
        /// Gets the author.
        /// </summary>
        /// <value>
        /// The author.
        /// </value>
        public string Author { get; }

        /// <summary>
        /// Gets the publisher.
        /// </summary>
        /// <value>
        /// The publisher.
        /// </value>
        public string Publisher { get; }

        /// <summary>
        /// Gets the publishing year.
        /// </summary>
        /// <value>
        /// The publishing year.
        /// </value>
        public string PublishingYear { get; }

        /// <summary>
        /// Gets the number of pages.
        /// </summary>
        /// <value>
        /// The number of pages.
        /// </value>
        public int NumberOfPages { get; }

        /// <summary>
        /// Gets the price.
        /// </summary>
        /// <value>
        /// The price.
        /// </value>
        public decimal Price { get; }

        /// <summary>
        /// Equalses the specified other book.
        /// </summary>
        /// <param name="otherBook">The other book.</param>
        /// <returns></returns>
        public bool Equals(Book otherBook)
        {
            if (ReferenceEquals(otherBook, null))
            {
                return false;
            }

            if (ReferenceEquals(this, otherBook))
            {
                return true;
            }

            return ValueEquality(otherBook);
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            return this.Equals((Book)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="other">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="other" /> in the sort order.  Zero This instance occurs in the same position in the sort order as <paramref name="other" />. Greater than zero This instance follows <paramref name="other" /> in the sort order.
        /// </returns>
        public int CompareTo(Book other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }
            else
            {
                return string.Compare(other.ISBN, this.ISBN, StringComparison.InvariantCultureIgnoreCase);
            }
        }

        /// <summary>
        /// Compares to.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <param name="comparer">The comparer.</param>
        /// <returns></returns>
        public int CompareTo(Book other, IComparer<Book> comparer)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }
            else
            {
                return comparer.Compare(this, other);
            }
        }

        /// <summary>
        /// Compares the current instance with another object of the same type and returns an integer that indicates whether the current instance precedes, follows, or occurs in the same position in the sort order as the other object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// A value that indicates the relative order of the objects being compared. The return value has these meanings: Value Meaning Less than zero This instance precedes <paramref name="obj" /> in the sort order. Zero This instance occurs in the same position in the sort order as <paramref name="obj" />. Greater than zero This instance follows <paramref name="obj" /> in the sort order.
        /// </returns>
        public int CompareTo(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return -1;
            }
            else
            {
              return CompareTo((Book)obj);
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="provider">The provider.</param>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        /// <exception cref="FormatException"></exception>
        public string ToString(string format, IFormatProvider provider)
        {
            if (string.IsNullOrEmpty(format))
            {
                format = "G";
            }

            if (provider == null)
            {
                provider = CultureInfo.CurrentCulture;
            }

            switch (format.ToUpperInvariant())
            {
                case "G": return $"{Title} {Author} {PublishingYear} {Price}";
                case "FULL":
                      return $"{Title} {Author} {Publisher} {PublishingYear} {NumberOfPages} {Price}";
                case "ISBN":
                    return $"{ISBN}";               
                default:
                    throw new FormatException(string.Format("The {0} format string is not supported.", format));
            }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Checks the input data.
        /// </summary>
        /// <param name="isbn">The isbn.</param>
        /// <param name="name">The name.</param>
        /// <param name="author">The author.</param>
        /// <param name="publisher">The publisher.</param>
        /// <param name="publishingYear">The publishing year.</param>
        /// <param name="numberOfPages">The number of pages.</param>
        /// <param name="price">The price.</param>
        /// <exception cref="ArgumentNullException">
        /// </exception>
        /// <exception cref="ArgumentException">
        /// numberOfPages
        /// or
        /// price
        /// </exception>
        private void CheckInputData(string isbn, string name, string author, string publisher, string publishingYear, int numberOfPages, decimal price)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentNullException($"{nameof(isbn)} is null or empty");
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"{nameof(name)} is null or empty");
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentNullException($"{nameof(author)} is null or empty");
            }

            if (string.IsNullOrWhiteSpace(publisher))
            {
                throw new ArgumentNullException($"{nameof(publisher)} is null or empty");
            }

            if (string.IsNullOrWhiteSpace(publishingYear))
            {
                throw new ArgumentNullException($"{nameof(PublishingYear)} is null or empty");
            }

            if (numberOfPages < 2)
            {
                throw new ArgumentException($"{nameof(numberOfPages)} must be greater than 2");
            }

            if (price < 0)
            {
                throw new ArgumentException($"{nameof(price)} must be greater than 2");
            }
        }

        /// <summary>
        /// Values the equality.
        /// </summary>
        /// <param name="otherBook">The other book.</param>
        /// <returns></returns>
        private bool ValueEquality(Book otherBook)
        {
            if (!string.Equals(ISBN, otherBook.ISBN, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            if (!string.Equals(Title, otherBook.Title, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            if (!string.Equals(Author, otherBook.Author, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            if (!string.Equals(Publisher, otherBook.Publisher, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            if (!string.Equals(PublishingYear, otherBook.PublishingYear, StringComparison.InvariantCultureIgnoreCase))
            {
                return false;
            }

            if (NumberOfPages != otherBook.NumberOfPages)
            {
                return false;
            }

            if (Price != otherBook.Price)
            {
                return false;
            }

            return true;
        }
    }
}

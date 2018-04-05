using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary
{
    public sealed class Book: IComparable<Book>,IComparable, IEquatable<Book>, IFormattable
    {
        public string ISBN { get; }
        public string Title { get; }
        public string Author { get; }        
        public string Publisher { get; }
        //public DateTime PublishingYear { get; }
        public string PublishingYear { get; }
        public int NumberOfPages { get; }
        public decimal Price { get; }

        public Book(string isbn, string title, string author,string publisher, string publishingYear, int numberOfPages, decimal price)
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


        private void CheckInputData(string isbn, string name, string author, string publisher, string publishingYear, int numberOfPages, decimal price)
        {
            if(string.IsNullOrWhiteSpace(isbn))
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

        public bool Equals(Book otherBook)
        {
            if(ReferenceEquals(otherBook, null))
            {
                return false;
            }
            if(ReferenceEquals(this, otherBook))
            {
                return true;
            }

            return ValueEquality(otherBook);
        }

        public bool Equals(Book otherBook, IComparer<Book> comparer)
        {
            if (ReferenceEquals(otherBook, null))
            {
                return false;
            }
            if (ReferenceEquals(this, otherBook))
            {
                return true;
            }

            return comparer.Compare(this,otherBook) == 0 ? true:false;
        }

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

            return Equals((Book)obj);
        }
 
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        private bool ValueEquality(Book otherBook)
        {
            if(!string.Equals(ISBN,otherBook.ISBN, StringComparison.InvariantCultureIgnoreCase))
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

        public int CompareTo(Book other)
        {
            if(ReferenceEquals(this,other))
            {
                return 0;
            }
            else
            {
                return string.Compare(other.ISBN,this.ISBN,StringComparison.InvariantCultureIgnoreCase);
            }
        }

        public int CompareTo(Book other,IComparer<Book> comparer)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }
            else
            {
                return comparer.Compare(this,other);
            }
        }

        public int CompareTo(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return -1;
            }
            else
            {
              return  CompareTo((Book)obj);
            }
        }

        public string ToString(string format, IFormatProvider provider)
        {
            if (String.IsNullOrEmpty(format)) format = "G";
            if (provider == null) provider = CultureInfo.CurrentCulture;

            switch (format.ToUpperInvariant())
            {
                case "G": return $"{Title} {Author} {PublishingYear} {Price}";
                case "FULL":
                      return $"{Title} {Author} {Publisher} {PublishingYear} {NumberOfPages} {Price}";
                case "ISBN":
                    return $"{ISBN}";               
                default:
                    throw new FormatException(String.Format("The {0} format string is not supported.", format));
            }
        }

        public override string ToString()
        {
            return ToString("G", CultureInfo.CurrentCulture);
        }
    }
}

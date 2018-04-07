using BookLibrary;
using System;
using System.Globalization;

namespace BookLibraryApplication
{
    public class CustomFormatProvider : IFormatProvider, ICustomFormatter
    {
        /// <summary>
        /// Returns an object that provides formatting services for the specified type.
        /// </summary>
        /// <param name="formatType">An object that specifies the type of format object to return.</param>
        /// <returns>
        /// An instance of the object specified by <paramref name="formatType" />, if the <see cref="T:System.IFormatProvider" /> implementation can supply that type of object; otherwise, null.
        /// </returns>
        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        /// <summary>
        /// Formats the specified format.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="argument">The argument.</param>
        /// <param name="prov">The prov.</param>
        /// <returns></returns>
        public string Format(string format, object argument, IFormatProvider prov)
        {
            if (argument.GetType() != typeof(Book))
            {
                return HandleOtherFormats(format, argument);
            }

            Book book = (Book)argument;

            switch (format)
            {
                case "TAP":
                    return $"{book.Title} {book.Author} {book.Price}";
                case "TAPY":
                    return $"{book.Title} {book.Author} {book.Price} {book.PublishingYear}";
                default:
                    return HandleOtherFormats(format, argument);
            }
        }

        /// <summary>
        /// Handles the other formats.
        /// </summary>
        /// <param name="format">The format.</param>
        /// <param name="argument">The argument.</param>
        /// <returns></returns>
        private string HandleOtherFormats(string format, object argument)
        {
            if (argument is IFormattable)
            {
                return ((IFormattable)argument).ToString(format, CultureInfo.CurrentCulture);
            }

            if (argument != null)
            {
                return argument.ToString();
            }

            return String.Empty;
        }
    }
}

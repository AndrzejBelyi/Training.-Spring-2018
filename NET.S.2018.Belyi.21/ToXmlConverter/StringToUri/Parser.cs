using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToXMLConverterLibrary.Interfaces;

namespace StringToUri
{
    public class Parser : IParser<string, Uri>
    {
        /// <summary>
        /// Parses the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">source</exception>
        public Uri Parse(string source)
        {
            if (String.IsNullOrWhiteSpace(source))
            {
                throw new ArgumentNullException($"{nameof(source)} is empty");
            }

            return new Uri(source);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using ToXMLConverterLibrary.Interfaces;

namespace StringToUri
{
    /// <summary>
    /// /Копипаста 
    /// </summary>
    /// <seealso cref="ToXMLConverterLibrary.Interfaces.IStorage{System.Uri}" />
    public class XMLStorage : IStorage<Uri>
    {
        /// <summary>
        /// The path
        /// </summary>
        private string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="XMLStorage"/> class.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <exception cref="ArgumentNullException">path</exception>
        public XMLStorage(string path)
        {
            if (String.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException($"{nameof(path)} is empty");
            }

            this.path = path;
        }

        /// <summary>
        /// Saves the specified uris.
        /// </summary>
        /// <param name="uris">The uris.</param>
        /// <exception cref="ArgumentNullException">path</exception>
        public void Save(IEnumerable<Uri> uris)
        {
            if (ReferenceEquals(uris, null))
            {
                throw new ArgumentNullException($"{nameof(path)} is empty");
            }

            XDocument document = new XDocument(new XDeclaration("1.0", "utf-16", null), new XElement("UrlAdress",uris.Select(uri => new XElement("UrlAdress",new XElement("host", new XAttribute("name", uri.Host)),
                new XElement("uri", GetTrimmedSegments(uri.Segments).Select(segment => new XElement("segment", segment))),
                new XElement("parameters", ParseQueryString(uri.Query).Select(pair => new XElement("parametr", new XAttribute("key",pair.Key),new XAttribute("value",pair.Value))))))));
            document.Descendants().Where(element => element.Name == "parametrs");
            document.Save(path);
        }

        /// <summary>
        /// Parses the query string.
        /// </summary>
        /// <param name="queryString">The query string.</param>
        /// <returns></returns>
        private static Dictionary<string, string> ParseQueryString(string queryString)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            if(String.IsNullOrWhiteSpace(queryString))
            {
                return result;
            }

            var query = from parametr in queryString.Substring(1).Split('&')
                        let splittedParametr = parametr.Split('=')
                        select new { key = splittedParametr[0], value = splittedParametr[1] };

            foreach (var item in query)
            {
                result.Add(item.key, item.value);
            }

            return result;
        }

        /// <summary>
        /// INVALID CODE!!!
        /// Gets the trimmed segments.
        /// </summary>
        /// <param name="segments">The segments.</param>
        /// <returns></returns>
        private static IEnumerable<string> GetTrimmedSegments(string[] segments)
        {
            return segments.AsEnumerable();                    
        }

    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToXMLConverterLibrary.Interfaces;

namespace StringToUri
{
    public class UriDataProvider : IDataProvider<string>
    {
        /// <summary>
        /// The filepath
        /// </summary>
        private string filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="UriDataProvider"/> class.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <exception cref="ArgumentNullException">filePath</exception>
        public UriDataProvider(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentNullException($"{nameof(filePath)} is empty");
            }

            this.filePath = filePath;
        }

        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> getData()
        {
            using (StreamReader streamReader = new StreamReader(new FileStream(filePath, FileMode.Open)))
            {
                yield return streamReader.ReadLine();
            }
        }
    }
}

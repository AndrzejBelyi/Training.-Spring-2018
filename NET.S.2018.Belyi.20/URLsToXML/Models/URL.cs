using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLsToXML.Models
{
    public sealed class URL
    {
        public string Scheme { get; }
        public string Host { get;}
        public IEnumerable<string> Segments { get; } = Enumerable.Empty<string>();
        public IEnumerable<KeyValuePair<string, string>> Parameters { get; } = Enumerable.Empty<KeyValuePair<string,string>>(); 

        public URL()
        {

        }

        public URL(string scheme, string host, IEnumerable<string> segments, IEnumerable<KeyValuePair<string,string>> parametrs)
        {
            Scheme = scheme;
            Host = host;
            Segments = segments;
            Parameters = parametrs;
        }
    }
}

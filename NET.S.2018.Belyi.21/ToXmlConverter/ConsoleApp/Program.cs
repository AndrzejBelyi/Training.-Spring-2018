using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StringToUri;
using ToXMLConverterLibrary;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new DataProcessor<string, Uri>(new UriDataProvider("data.txt"),
                new Mapper<string,Uri>(new Parser(),new Validator()),new XMLStorage("res.xml"));

            processor.Process();
        }
    }
}

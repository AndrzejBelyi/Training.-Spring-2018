using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using URLsToXML.Models;

namespace URLsToXML.Converters
{
    class DefaultUrlToXmlConverter : Interfaces.IUrlToXmlConverter
    {
        public XElement Convert(URL url)
        {
            using (var memoryStream = new MemoryStream())
            {
                using (TextWriter streamWriter = new StreamWriter(memoryStream))
                {
                    var xmlSerializer = new XmlSerializer(typeof(URL));
                    xmlSerializer.Serialize(streamWriter, url);
                    return XElement.Parse(Encoding.ASCII.GetString(memoryStream.ToArray()));
                }
            }
        }
    }
}

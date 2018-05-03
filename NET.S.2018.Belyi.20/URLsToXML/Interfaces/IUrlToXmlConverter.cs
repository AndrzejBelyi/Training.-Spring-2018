using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace URLsToXML.Interfaces
{
    public interface IUrlToXmlConverter
    {
        XElement Convert(Models.URL url);
    }
}

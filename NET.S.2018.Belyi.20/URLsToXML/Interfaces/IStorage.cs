using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLsToXML.Interfaces
{
    public interface IStorage
    {
        IEnumerable<Models.URL> GetURL();
    }
}

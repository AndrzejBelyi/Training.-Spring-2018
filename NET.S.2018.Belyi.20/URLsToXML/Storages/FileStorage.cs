using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using URLsToXML.Models;

namespace URLsToXML.Storages
{
    class FileStorage : Interfaces.IStorage
    {
        public IEnumerable<URL> GetURL()
        {
            throw new NotImplementedException();
        }
    }
}

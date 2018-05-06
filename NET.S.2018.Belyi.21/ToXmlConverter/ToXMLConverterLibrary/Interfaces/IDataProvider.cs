using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToXMLConverterLibrary.Interfaces
{
    public interface IDataProvider<out T>
    {
        /// <summary>
        /// Gets the data.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> getData();
    }
}

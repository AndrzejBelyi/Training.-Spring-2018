using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToXMLConverterLibrary.Interfaces
{
    public interface IStorage<in T>
    {
        /// <summary>
        /// Saves the specified entities.
        /// </summary>
        /// <param name="entities">The entities.</param>
        void Save(IEnumerable<T> entities);
    }
}

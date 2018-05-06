using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToXMLConverterLibrary.Interfaces
{
    public interface IMapper<in TSource,out TResult>
    {
        /// <summary>
        /// Maps the specified lines.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <returns></returns>
        IEnumerable<TResult> Map(IEnumerable<TSource> lines);
    }
}

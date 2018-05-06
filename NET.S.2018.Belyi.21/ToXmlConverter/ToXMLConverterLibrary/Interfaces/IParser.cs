using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToXMLConverterLibrary.Interfaces
{
    public interface IParser<in TSource, out TResult>
    {
        /// <summary>
        /// Parses the specified source.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns></returns>
        TResult Parse(TSource source);
    }
}

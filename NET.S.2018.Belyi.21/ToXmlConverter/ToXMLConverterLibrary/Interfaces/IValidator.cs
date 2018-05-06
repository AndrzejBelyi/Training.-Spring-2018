using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToXMLConverterLibrary.Interfaces
{
    public interface IValidator<in T>
    {
        /// <summary>
        /// Determines whether the specified entity is valid.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        ///   <c>true</c> if the specified entity is valid; otherwise, <c>false</c>.
        /// </returns>
        bool isValid(T entity);
    }
}

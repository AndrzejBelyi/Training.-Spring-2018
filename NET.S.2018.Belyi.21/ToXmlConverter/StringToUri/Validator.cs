using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToXMLConverterLibrary.Interfaces;

namespace StringToUri
{
    public class Validator : IValidator<string>
    {
        /// <summary>
        /// Determines whether the specified entity is valid.
        /// </summary>
        /// <param name="entity">The entity.</param>
        /// <returns>
        /// <c>true</c> if the specified entity is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool isValid(string entity)
        {
            if (String.IsNullOrWhiteSpace(entity))
            {
                return false;
            }

            return entity.Split(new string[] { "://", "/" }, StringSplitOptions.None).Length < 3;
        }
    }
}

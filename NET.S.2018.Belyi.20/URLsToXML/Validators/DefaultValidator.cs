using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLsToXML.Validators
{
    class DefaultValidator : Interfaces.IUrlValidator
    {
        /// <summary>
        /// Returns true if is valid.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>
        ///   <c>true</c> if the specified URL is valid; otherwise, <c>false</c>.
        /// </returns>
        public bool IsValid(string url)
        {
            if (String.IsNullOrWhiteSpace(url))
            {
                return false;
            }

            return url.Split(new string[] { "://", "/" }, StringSplitOptions.None).Length < 3;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToXMLConverterLibrary.Interfaces;

namespace ToXMLConverterLibrary
{
    public sealed class Mapper<TSource, TResult> : IMapper<TSource, TResult>
    {
        /// <summary>
        /// The parser
        /// </summary>
        private IParser<TSource, TResult> parser;

        /// <summary>
        /// The validator
        /// </summary>
        private IValidator<TSource> validator;

        /// <summary>
        /// Initializes a new instance of the <see cref="Mapper{TSource, TResult}"/> class.
        /// </summary>
        /// <param name="parser">The parser.</param>
        /// <param name="validator">The validator.</param>
        /// <exception cref="ArgumentNullException">
        /// parser
        /// or
        /// validator
        /// </exception>
        public Mapper(IParser<TSource, TResult> parser ,IValidator<TSource> validator)
        {
            if (ReferenceEquals(parser, null))
            {
                throw new ArgumentNullException($"{nameof(parser)} is empty");
            }

            if (ReferenceEquals(validator, null))
            {
                throw new ArgumentNullException($"{nameof(validator)} is empty");
            }

            this.parser = parser;
            this.validator = validator;
        }

        /// <summary>
        /// Maps the specified lines.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">lines</exception>
        public IEnumerable<TResult> Map(IEnumerable<TSource> lines)
        {
            if (ReferenceEquals(lines, null))
            {
                throw new ArgumentNullException($"{nameof(lines)} is empty");
            }

            foreach (var line in lines)
            {
                if(validator.isValid(line))
                {
                    yield return parser.Parse(line);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToXMLConverterLibrary.Interfaces;

namespace ToXMLConverterLibrary
{
    public sealed class DataProcessor<TSource, TResult>
    {
        /// <summary>
        /// The data provider
        /// </summary>
        private readonly IDataProvider<TSource> dataProvider;

        /// <summary>
        /// The mapper
        /// </summary>
        private readonly IMapper<TSource, TResult> mapper;

        /// <summary>
        /// The storage
        /// </summary>
        private readonly IStorage<TResult> storage;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataProcessor{TSource, TResult}"/> class.
        /// </summary>
        /// <param name="dataProvider">The data provider.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="storage">The storage.</param>
        /// <exception cref="ArgumentNullException">
        /// dataProvider
        /// or
        /// mapper
        /// or
        /// storage
        /// </exception>
        public DataProcessor(IDataProvider<TSource> dataProvider, IMapper<TSource, TResult> mapper, IStorage<TResult> storage)
        {
            if(ReferenceEquals(dataProvider,null))
            {
                throw new ArgumentNullException($"{nameof(dataProvider)} is empty");
            }

            if (ReferenceEquals(dataProvider, null))
            {
                throw new ArgumentNullException($"{nameof(mapper)} is empty");
            }

            if (ReferenceEquals(dataProvider, null))
            {
                throw new ArgumentNullException($"{nameof(storage)} is empty");
            }

            this.dataProvider = dataProvider;
            this.mapper = mapper;
            this.storage = storage;
        }

        /// <summary>
        /// Processes this instance.
        /// </summary>
        public void Process()
        {
            IEnumerable<TSource> lines = dataProvider.getData();
            IEnumerable<TResult> results = mapper.Map(lines);
            storage.Save(results);
        }
    }
}

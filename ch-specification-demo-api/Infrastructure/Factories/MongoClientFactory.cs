using ch_specification_demo_api.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace ch_specification_demo_api.Infrastructure.Factories
{
    public class MongoClientFactory : IMongoClientFactory
    {
        private readonly IOptions<MongoDbSettings> _options;

        public MongoClientFactory(IOptions<MongoDbSettings> options)
        {
            _options = options
                ?? throw new ArgumentNullException(nameof(options));
        }

        public MongoClient Client => new MongoClient(_options.Value.ConnectionString);
    }
}

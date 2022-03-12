using MongoDB.Driver;

namespace ch_specification_demo_api.Infrastructure.Factories
{
    public interface IMongoClientFactory
    {
        MongoClient Client { get; }
    }
}

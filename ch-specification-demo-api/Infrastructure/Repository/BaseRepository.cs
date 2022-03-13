using ch_specification_demo_api.Infrastructure.Factories;
using ch_specification_demo_api.Infrastructure.Specification;
using ch_specification_demo_api.Models;
using MongoDB.Driver;

namespace ch_specification_demo_api.Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseModel
    {
        private readonly IMongoCollection<T> _collection;

        public BaseRepository(IMongoClientFactory factory)
        {
            var mongoDatabase = factory.Client.GetDatabase(Constants.MongoCatalogs.Demo);

            _collection = mongoDatabase.GetCollection<T>(Constants.MongoCollections.Beers);
        }

        public async Task<IEnumerable<T>> Get(ISpecification<T> filter)
        {
            return await ApplyFilter(filter).ToListAsync();
        }

        private IFindFluent<T,T> ApplyFilter(ISpecification<T> specification)
        {
            return SpecificationEvaluator<T>.Process(_collection, specification);
        }
    }
}

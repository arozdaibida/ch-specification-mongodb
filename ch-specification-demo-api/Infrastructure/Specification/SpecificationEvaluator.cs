using ch_specification_demo_api.Models;
using MongoDB.Driver;

namespace ch_specification_demo_api.Infrastructure.Specification
{
    public class SpecificationEvaluator<T> where T : BaseModel
    {
        public static IFindFluent<T, T> Process(
            IMongoCollection<T> inputQuery, 
            ISpecification<T> specification)
        {
            var query = null as IFindFluent<T, T>;

            query = specification.Select is not null ? 
                inputQuery.Find(specification.Select) : 
                inputQuery.Find(_ => true);

            query = Sort(query, specification);

            if (specification.IsPagingEnable)
            {
                query = query.Skip(specification.Skip).Limit(specification.Take);
            }

            return query;
        }

        private static IFindFluent<T,T> Sort(IFindFluent<T, T> query, ISpecification<T> specification)
        {
            if(specification.OrderBy is not null)
            {
                query = query.SortBy(specification.OrderBy);
            }
            else if(specification.OrderByDesc is not null)
            {
                query = query.SortByDescending(specification.OrderByDesc);
            }

            return query;
        }
    }
}

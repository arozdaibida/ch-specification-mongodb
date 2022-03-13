using ch_specification_demo_api.Infrastructure.Specification;
using ch_specification_demo_api.Models;

namespace ch_specification_demo_api.Infrastructure.Repository
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> Get(ISpecification<T> filter);
    }
}

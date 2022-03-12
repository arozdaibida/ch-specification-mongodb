using ch_specification_demo_api.Models;
using System.Linq.Expressions;

namespace ch_specification_demo_api.Infrastructure.Repository
{
    public interface IBaseRepository<T> where T : BaseModel
    {
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter);
    }
}

using ch_specification_demo_api.Models;
using System.Linq.Expressions;

namespace ch_specification_demo_api.Infrastructure.Specification
{
    public interface ISpecification<T> where T : BaseModel
    {
        public Expression<Func<T, bool>> Select { get; protected set; }

        public Expression<Func<T, object>> OrderBy { get; protected set; }

        public Expression<Func<T, object>> OrderByDesc { get; protected set; }

        public int Take { get; protected set; }

        public int Skip { get; protected set; }

        public bool IsPagingEnable { get; protected set; }
    }
}

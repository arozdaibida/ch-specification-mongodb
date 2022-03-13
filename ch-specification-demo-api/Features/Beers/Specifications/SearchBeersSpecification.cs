using ch_specification_demo_api.Features.Beers.Models;
using ch_specification_demo_api.Infrastructure.Specification;
using ch_specification_demo_api.Models;
using System.Linq.Expressions;

namespace ch_specification_demo_api.Features.Beers.Specifications
{
    public class SearchBeersSpecification : ISpecification<Beer>
    {
        public SearchBeersSpecification(GetBeersRequest request)
        {
            Select = x => x.Name.Contains(request.SearchFilter);

            if(request.OrderType is Constants.OrderType.Asc)
            {
                OrderBy = GetOrderBy(request.OrderBy);
            }
            else if(request.OrderType is Constants.OrderType.Desc)
            {
                OrderByDesc = GetOrderBy(request.OrderType);
            }

            Skip = request.Page is 1 ? 0 : request.Page * request.PageSize;

            Take = request.PageSize;

            IsPagingEnable = request.IsPagingEnable;
        }

        public Expression<Func<Beer, bool>> Select { get; set; }
        public Expression<Func<Beer, object>> OrderBy { get; set; }
        public Expression<Func<Beer, object>> OrderByDesc { get; set; }
        public int Take { get; set; }
        public int Skip { get; set; }
        public bool IsPagingEnable { get; set; }

        private Expression<Func<Beer, object>> GetOrderBy(string orderBy)
        {
            return orderBy switch
            {
                nameof(Beer.Price) => x => x.Price,
                nameof(Beer.Name) => x => x.Name,
                nameof(Beer.Rating) => x => x.Rating,
                _ => null
            };
        }
    }


}

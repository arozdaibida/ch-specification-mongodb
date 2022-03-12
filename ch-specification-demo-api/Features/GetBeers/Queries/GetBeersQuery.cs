using ch_specification_demo_api.Models;
using MediatR;

namespace ch_specification_demo_api.Features.GetBeers.Queries
{
    public class GetBeersQuery: IRequest<IEnumerable<Beer>>
    {
        public string SearchFilter { get; set; }
    }
}

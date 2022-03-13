using ch_specification_demo_api.Features.Beers.Models;
using ch_specification_demo_api.Models;
using MediatR;

namespace ch_specification_demo_api.Features.Beers.Queries
{
    public class GetBeersQuery: IRequest<IEnumerable<Beer>>
    {
        public GetBeersRequest Request { get; set; }
    }
}

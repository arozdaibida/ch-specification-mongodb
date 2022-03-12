using ch_specification_demo_api.Features.GetBeers.Queries;
using FastEndpoints;
using MediatR;

namespace ch_specification_demo_api.Features.GetBeers.Endpoints
{
    public class GetBeerEndpoint : Endpoint<GetBeerRequest>
    {
        private readonly ISender _mediator;

        public GetBeerEndpoint(ISender mediator)
        {
            _mediator = mediator
                ?? throw new ArgumentNullException(nameof(mediator));
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("/demo");
            AllowAnonymous();
        }

        public override async Task HandleAsync(GetBeerRequest req, CancellationToken ct)
        {
            await _mediator.Send(new GetBeersQuery
            {
                SearchFilter = req.SearchFilter
            });
        }
    }
}

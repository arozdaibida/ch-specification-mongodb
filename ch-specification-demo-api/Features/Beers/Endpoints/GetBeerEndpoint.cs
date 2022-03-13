using ch_specification_demo_api.Features.Beers.Models;
using ch_specification_demo_api.Features.Beers.Queries;
using FastEndpoints;
using MediatR;

namespace ch_specification_demo_api.Features.Beers.Endpoints
{
    public class GetBeerEndpoint : Endpoint<GetBeersRequest>
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

        public override async Task HandleAsync(GetBeersRequest req, CancellationToken ct)
        {
            var beers = await _mediator.Send(new GetBeersQuery
            {
                Request = req
            });

            await SendAsync(beers);
        }
    }
}

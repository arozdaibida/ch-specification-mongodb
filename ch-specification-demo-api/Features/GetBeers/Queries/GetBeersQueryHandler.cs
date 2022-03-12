using ch_specification_demo_api.Infrastructure.Repository;
using ch_specification_demo_api.Models;
using MediatR;

namespace ch_specification_demo_api.Features.GetBeers.Queries
{
    public class GetBeersQueryHandler : IRequestHandler<GetBeersQuery, IEnumerable<Beer>>
    {
        private readonly IBaseRepository<Beer> _repository;

        public GetBeersQueryHandler(IBaseRepository<Beer> repository)
        {
            _repository = repository
                ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<IEnumerable<Beer>> Handle(GetBeersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.Get(x => x.Name.Contains(request.SearchFilter));
        }
    }
}

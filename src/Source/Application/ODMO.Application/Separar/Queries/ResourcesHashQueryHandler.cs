using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class ResourcesHashQueryHandler : IRequestHandler<ResourcesHashQuery, string>
    {
        private readonly IServerQueriesRepository _repository;

        public ResourcesHashQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<string> Handle(ResourcesHashQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetResourcesHashAsync();
        }
    }
}
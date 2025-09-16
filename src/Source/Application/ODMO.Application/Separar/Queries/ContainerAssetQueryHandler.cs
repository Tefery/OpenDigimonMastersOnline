using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class ContainerAssetQueryHandler : IRequestHandler<ContainerAssetQuery, List<ContainerAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public ContainerAssetQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ContainerAssetDTO>> Handle(ContainerAssetQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetContainerAssetsAsync();
        }
    }
}
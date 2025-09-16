using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class CloneItemAssetsQueryHandler : IRequestHandler<CloneItemAssetsQuery, List<ItemAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public CloneItemAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ItemAssetDTO>> Handle(CloneItemAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCloneItemAssetsAsync();
        }
    }
}

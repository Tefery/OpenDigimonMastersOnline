using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class AccessoryRollAssetsQueryHandler : IRequestHandler<AccessoryRollAssetsQuery, List<AccessoryRollAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public AccessoryRollAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AccessoryRollAssetDTO>> Handle(AccessoryRollAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAccessoryRollInfoAsync();
        }
    }
}

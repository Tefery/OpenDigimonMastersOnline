using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class MapAssetsQueryHandler : IRequestHandler<MapAssetsQuery, List<MapAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public MapAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MapAssetDTO>> Handle(MapAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMapAssetsAsync();
        }
    }
}
using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class MapRegionListAssetsByMapIdQueryHandler : IRequestHandler<MapRegionListAssetsByMapIdQuery, MapRegionListAssetDTO?>
    {
        private readonly IServerQueriesRepository _repository;

        public MapRegionListAssetsByMapIdQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<MapRegionListAssetDTO?> Handle(MapRegionListAssetsByMapIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMapRegionListAssetsAsync(request.MapId);
        }
    }
}
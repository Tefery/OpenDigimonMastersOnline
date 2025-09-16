using MediatR;
using ODMO.Commons.DTOs.Assets;

namespace ODMO.Application.Separar.Queries
{
    public class MapRegionListAssetsByMapIdQuery : IRequest<MapRegionListAssetDTO?>
    {
        public int MapId { get; private set; }

        public MapRegionListAssetsByMapIdQuery(int mapId)
        {
            MapId = mapId;
        }
    }
}
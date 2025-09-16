using ODMO.Commons.DTOs.Assets;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class UpdateSpawnPointCommand : IRequest
    {
        public long MapId { get; }
        public MapRegionAssetDTO SpawnPoint { get; }

        public UpdateSpawnPointCommand(MapRegionAssetDTO spawnPoint, long mapId)
        {
            SpawnPoint = spawnPoint;
            MapId = mapId;
        }
    }
}
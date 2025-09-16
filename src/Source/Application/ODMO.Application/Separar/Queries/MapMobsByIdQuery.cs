using MediatR;
using ODMO.Commons.DTOs.Config;

namespace ODMO.Application.Separar.Queries
{
    public class MapMobsByIdQuery : IRequest<List<MobConfigDTO>>
    {
        public int MapId { get; private set; }

        public MapMobsByIdQuery(int mapId)
        {
            MapId = mapId;
        }
    }
}
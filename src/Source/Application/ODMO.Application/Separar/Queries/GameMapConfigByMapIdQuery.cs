using MediatR;
using ODMO.Commons.DTOs.Config;

namespace ODMO.Application.Separar.Queries
{
    public class GameMapConfigByMapIdQuery : IRequest<MapConfigDTO?>
    {
        public int MapId { get; private set; }

        public GameMapConfigByMapIdQuery(int mapId)
        {
            MapId = mapId;
        }
    }
}
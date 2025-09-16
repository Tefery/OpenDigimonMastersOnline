using MediatR;
using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Enums;

namespace ODMO.Application.Separar.Queries
{
    public class GameMapsConfigQuery : IRequest<List<MapConfigDTO>>
    {
        public MapTypeEnum Type { get; }

        public GameMapsConfigQuery(MapTypeEnum type = MapTypeEnum.Default)
        {
            Type = type;
        }
    }
}
using MediatR;
using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Enums;

namespace ODMO.Application.Separar.Queries
{
    public class TamerLevelStatusQuery : IRequest<CharacterLevelStatusAssetDTO>
    {
        public CharacterModelEnum Type { get; private set; }

        public byte Level { get; private set; }

        public TamerLevelStatusQuery(CharacterModelEnum type, byte level)
        {
            Type = type;
            Level = level;
        }
    }
}
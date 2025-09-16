using MediatR;
using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Enums;

namespace ODMO.Application.Separar.Queries
{
    public class TamerBaseStatusQuery : IRequest<CharacterBaseStatusAssetDTO>
    {
        public CharacterModelEnum Type { get; private set; }

        public TamerBaseStatusQuery(CharacterModelEnum type)
        {
            Type = type;
        }
    }
}
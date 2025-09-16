using MediatR;
using ODMO.Commons.DTOs.Assets;

namespace ODMO.Application.Separar.Queries
{
    public class DigimonEvolutionAssetsByTypeQuery : IRequest<EvolutionAssetDTO?>
    {
        public int Type { get; }

        public DigimonEvolutionAssetsByTypeQuery(int type)
        {
            Type = type;
        }
    }
}
using MediatR;
using ODMO.Commons.DTOs.Assets;

namespace ODMO.Application.Separar.Queries
{
    public class DigimonEvolutionAssetsQuery : IRequest<List<EvolutionAssetDTO>>
    {
    }
}
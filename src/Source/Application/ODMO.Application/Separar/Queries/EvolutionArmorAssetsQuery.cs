using MediatR;
using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.DTOs.Config;

namespace ODMO.Application.Separar.Queries
{
    public class EvolutionArmorAssetsQuery : IRequest<List<EvolutionArmorAssetDTO>>
    {
    }
}


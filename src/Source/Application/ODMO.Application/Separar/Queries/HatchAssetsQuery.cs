using MediatR;
using ODMO.Commons.DTOs.Assets;

namespace ODMO.Application.Separar.Queries
{
    public class HatchAssetsQuery : IRequest<List<HatchAssetDTO>>
    {
    }
}
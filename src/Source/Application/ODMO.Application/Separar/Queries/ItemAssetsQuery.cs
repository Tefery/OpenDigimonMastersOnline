using MediatR;
using ODMO.Commons.DTOs.Assets;

namespace ODMO.Application.Separar.Queries
{
    public class ItemAssetsQuery : IRequest<List<ItemAssetDTO>>
    {
    }
}


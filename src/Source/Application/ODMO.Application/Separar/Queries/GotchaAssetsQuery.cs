using MediatR;
using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Models.Asset;

namespace ODMO.Application.Separar.Queries
{
    public class GotchaAssetsQuery : IRequest<List<GotchaAssetDTO>>
    {

    }
}
using MediatR;
using ODMO.Commons.DTOs.Assets;

namespace ODMO.Application.Separar.Queries
{
    public class NpcColiseumAssetsQuery : IRequest<List<NpcColiseumAssetDTO>>
    {
    }
}
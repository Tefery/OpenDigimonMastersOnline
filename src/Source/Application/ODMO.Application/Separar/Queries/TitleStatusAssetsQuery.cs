using MediatR;
using ODMO.Commons.DTOs.Assets;

namespace ODMO.Application.Separar.Queries
{
    public class TitleStatusAssetsQuery : IRequest<TitleStatusAssetDTO>
    {
        public short TitleId { get; set; }

        public TitleStatusAssetsQuery(short titleId)
        {
            TitleId = titleId;
        }
    }
}
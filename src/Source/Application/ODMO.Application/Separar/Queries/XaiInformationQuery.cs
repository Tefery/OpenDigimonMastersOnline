using MediatR;
using ODMO.Commons.DTOs.Assets;

namespace ODMO.Application.Separar.Queries
{
    public class XaiInformationQuery : IRequest<XaiAssetDTO>
    {
        public int ItemId { get; private set; }

        public XaiInformationQuery(int itemId)
        {
            ItemId = itemId;
        }
    }
}
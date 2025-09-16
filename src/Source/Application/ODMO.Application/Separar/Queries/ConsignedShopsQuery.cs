using MediatR;
using ODMO.Commons.DTOs.Shop;

namespace ODMO.Application.Separar.Queries
{
    public class ConsignedShopsQuery : IRequest<IList<ConsignedShopDTO>>
    {
        public int MapId { get; private set; }

        public ConsignedShopsQuery(int mapId)
        {
            MapId = mapId;
        }
    }
}
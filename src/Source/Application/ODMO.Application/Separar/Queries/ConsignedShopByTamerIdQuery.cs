using MediatR;
using ODMO.Commons.DTOs.Shop;

namespace ODMO.Application.Separar.Queries
{
    public class ConsignedShopByTamerIdQuery : IRequest<ConsignedShopDTO?>
    {
        public long CharacterId { get; private set; }

        public ConsignedShopByTamerIdQuery(long characterId)
        {
            CharacterId = characterId;
        }
    }
}
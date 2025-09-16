using ODMO.Commons.Models.TamerShop;
using ODMO.Commons.DTOs.Shop;
using MediatR;

namespace ODMO.Application.Separar.Commands.Create
{
    public class CreateConsignedShopCommand : IRequest<ConsignedShopDTO>
    {
        public ConsignedShop ConsignedShop { get; set; }

        public CreateConsignedShopCommand(ConsignedShop consignedShop)
        {
            ConsignedShop = consignedShop;
        }
    }
}
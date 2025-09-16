using MediatR;
using ODMO.Commons.DTOs.Shop;

namespace ODMO.Application.Separar.Queries
{
    public class ConsignedShopByHandlerQuery : IRequest<ConsignedShopDTO>
    {
        public long GeneralHandler { get; private set; }

        public ConsignedShopByHandlerQuery(long generalHandler)
        {
            GeneralHandler = generalHandler;
        }
    }
}
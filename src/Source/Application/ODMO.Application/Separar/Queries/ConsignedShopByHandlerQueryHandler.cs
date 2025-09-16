using ODMO.Commons.DTOs.Shop;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class ConsignedShopByHandlerQueryHandler : IRequestHandler<ConsignedShopByHandlerQuery, ConsignedShopDTO>
    {
        private readonly IServerQueriesRepository _repository;

        public ConsignedShopByHandlerQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ConsignedShopDTO> Handle(ConsignedShopByHandlerQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetConsignedShopByHandlerAsync(request.GeneralHandler);
        }
    }
}

using ODMO.Commons.DTOs.Shop;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class ConsignedShopByTamerIdQueryHandler : IRequestHandler<ConsignedShopByTamerIdQuery, ConsignedShopDTO?>
    {
        private readonly IServerQueriesRepository _repository;

        public ConsignedShopByTamerIdQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ConsignedShopDTO?> Handle(ConsignedShopByTamerIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetConsignedShopByTamerIdAsync(request.CharacterId);
        }
    }
}

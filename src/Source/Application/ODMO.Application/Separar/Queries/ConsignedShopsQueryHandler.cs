using ODMO.Commons.DTOs.Shop;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class ConsignedShopsQueryHandler : IRequestHandler<ConsignedShopsQuery, IList<ConsignedShopDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public ConsignedShopsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<ConsignedShopDTO>> Handle(ConsignedShopsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetConsignedShopsAsync(request.MapId);
        }
    }
}

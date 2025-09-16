using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Asset;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class CashShopAssetsQueryHandler : IRequestHandler<CashShopAssetsQuery, List<CashShopAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public CashShopAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CashShopAssetDTO>> Handle(CashShopAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCashShopAssetsAsync();
        }
    }
}
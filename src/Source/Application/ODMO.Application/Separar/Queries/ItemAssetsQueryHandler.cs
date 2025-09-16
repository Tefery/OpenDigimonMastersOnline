using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class ItemAssetsQueryHandler : IRequestHandler<ItemAssetsQuery, List<ItemAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public ItemAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ItemAssetDTO>> Handle(ItemAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetItemAssetsAsync();
        }
    }
}
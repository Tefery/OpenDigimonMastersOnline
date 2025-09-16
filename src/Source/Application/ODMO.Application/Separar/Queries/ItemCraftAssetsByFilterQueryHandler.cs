using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class ItemCraftAssetsByFilterQueryHandler : IRequestHandler<ItemCraftAssetsByFilterQuery, ItemCraftAssetDTO?>
    {
        private readonly IServerQueriesRepository _repository;

        public ItemCraftAssetsByFilterQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ItemCraftAssetDTO?> Handle(ItemCraftAssetsByFilterQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetItemCraftAssetsByFilterAsync(request.NpcId, request.SeqId);
        }
    }
}

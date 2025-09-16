using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.DTOs.Events;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Asset;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class DeckBuffAssetsQueryHandler : IRequestHandler<DeckBuffAssetsQuery, List<DeckBuffAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public DeckBuffAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DeckBuffAssetDTO>> Handle(DeckBuffAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDeckBuffAssetsAsync();
        }
    }
}
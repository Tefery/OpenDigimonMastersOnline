using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class TamerLevelingAssetsQueryHandler : IRequestHandler<TamerLevelingAssetsQuery, List<CharacterLevelStatusAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public TamerLevelingAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CharacterLevelStatusAssetDTO>> Handle(TamerLevelingAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTamerLevelAssetsAsync();
        }
    }
}
using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Asset;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class AchievementAssetsQueryHandler : IRequestHandler<AchievementAssetsQuery, List<AchievementAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public AchievementAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<AchievementAssetDTO>> Handle(AchievementAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAchievementAssetsAsync();
        }
    }
}
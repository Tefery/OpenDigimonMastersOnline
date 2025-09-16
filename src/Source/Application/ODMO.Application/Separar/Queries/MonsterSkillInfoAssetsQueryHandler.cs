using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class MonsterSkillInfoAssetsQueryHandler : IRequestHandler<MonsterSkillInfoAssetsQuery, List<MonsterSkillInfoAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public MonsterSkillInfoAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MonsterSkillInfoAssetDTO>> Handle(MonsterSkillInfoAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMonsterSkillInfoAssetsAsync();
        }
    }
}
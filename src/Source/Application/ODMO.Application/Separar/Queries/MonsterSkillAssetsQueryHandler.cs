using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class MonsterSkillAssetsQueryHandler : IRequestHandler<MonsterSkillAssetsQuery, List<MonsterSkillAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public MonsterSkillAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MonsterSkillAssetDTO>> Handle(MonsterSkillAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMonsterSkillSkillAssetsAsync();
        }
    }
}
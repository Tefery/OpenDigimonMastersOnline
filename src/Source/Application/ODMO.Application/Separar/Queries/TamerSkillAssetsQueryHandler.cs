using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class TamerSkillAssetsQueryHandler : IRequestHandler<TamerSkillAssetsQuery, List<TamerSkillAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public TamerSkillAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TamerSkillAssetDTO>> Handle(TamerSkillAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTamerSkillAssetsAsync();
        }
    }
}
using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class SkillCodeAssetsQueryHandler : IRequestHandler<SkillCodeAssetsQuery, List<SkillCodeAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public SkillCodeAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SkillCodeAssetDTO>> Handle(SkillCodeAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSkillCodeAssetsAsync();
        }
    }
}
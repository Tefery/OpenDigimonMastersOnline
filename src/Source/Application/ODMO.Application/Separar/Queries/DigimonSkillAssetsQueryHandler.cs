using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class DigimonSkillAssetsQueryHandler : IRequestHandler<DigimonSkillAssetsQuery, List<DigimonSkillAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public DigimonSkillAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DigimonSkillAssetDTO>> Handle(DigimonSkillAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDigimonSkillAssetsAsync();
        }
    }
}
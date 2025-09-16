using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class DigimonEvolutionAssetsQueryHandler : IRequestHandler<DigimonEvolutionAssetsQuery, List<EvolutionAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public DigimonEvolutionAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EvolutionAssetDTO>> Handle(DigimonEvolutionAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDigimonEvolutionAssetsAsync();
        }
    }
}
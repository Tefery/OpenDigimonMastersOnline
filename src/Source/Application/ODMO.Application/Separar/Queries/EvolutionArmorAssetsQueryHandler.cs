using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class EvolutionArmorAssetsQueryHandler : IRequestHandler<EvolutionArmorAssetsQuery, List<EvolutionArmorAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public EvolutionArmorAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EvolutionArmorAssetDTO>> Handle(EvolutionArmorAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetEvolutionArmorAssetsAsync();
        }
    }
}
using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class DigimonLevelingAssetsQueryHandler : IRequestHandler<DigimonLevelingAssetsQuery, List<DigimonLevelStatusAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public DigimonLevelingAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<DigimonLevelStatusAssetDTO>> Handle(DigimonLevelingAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDigimonLevelAssetsAsync();
        }
    }
}
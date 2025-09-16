using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class DigimonLevelStatusQueryHandler : IRequestHandler<DigimonLevelStatusQuery, DigimonLevelStatusAssetDTO>
    {
        private readonly IServerQueriesRepository _repository;

        public DigimonLevelStatusQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<DigimonLevelStatusAssetDTO> Handle(DigimonLevelStatusQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDigimonLevelingStatusAsync(request.Type, request.Level);
        }
    }
}
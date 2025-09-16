using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class DigimonBaseInfoQueryHandler : IRequestHandler<DigimonBaseInfoQuery, DigimonBaseInfoAssetDTO?>
    {
        private readonly IServerQueriesRepository _repository;

        public DigimonBaseInfoQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<DigimonBaseInfoAssetDTO?> Handle(DigimonBaseInfoQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDigimonBaseInfoAsync(request.Type);
        }
    }
}

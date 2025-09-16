using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class TamerBaseStatusQueryHandler : IRequestHandler<TamerBaseStatusQuery, CharacterBaseStatusAssetDTO>
    {
        private readonly IServerQueriesRepository _repository;

        public TamerBaseStatusQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<CharacterBaseStatusAssetDTO> Handle(TamerBaseStatusQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTamerBaseStatusAsync(request.Type);
        }
    }
}
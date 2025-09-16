using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GameMapsConfigQueryHandler : IRequestHandler<GameMapsConfigQuery, List<MapConfigDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public GameMapsConfigQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MapConfigDTO>> Handle(GameMapsConfigQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetGameMapsConfigAsync(request.Type);
        }
    }
}
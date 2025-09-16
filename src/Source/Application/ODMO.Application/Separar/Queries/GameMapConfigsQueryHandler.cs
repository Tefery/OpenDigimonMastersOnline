using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GameMapConfigsQueryHandler : IRequestHandler<GameMapConfigsQuery, IList<MapConfigDTO>>
    {
        private readonly IConfigQueriesRepository _repository;

        public GameMapConfigsQueryHandler(IConfigQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<MapConfigDTO>> Handle(GameMapConfigsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetGameMapConfigsAsync();
        }
    }
}
using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GameMapConfigByIdQueryHandler : IRequestHandler<GameMapConfigByIdQuery, MapConfigDTO?>
    {
        private readonly IConfigQueriesRepository _repository;

        public GameMapConfigByIdQueryHandler(IConfigQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<MapConfigDTO?> Handle(GameMapConfigByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetGameMapConfigByIdAsync(request.Id);
        }
    }
}
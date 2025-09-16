using ODMO.Commons.DTOs.Events;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Mechanics;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GetArenaRankingQueryHandler : IRequestHandler<GetArenaRankingQuery, ArenaRankingDTO>
    {
        private readonly IServerQueriesRepository _repository;

        public GetArenaRankingQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ArenaRankingDTO> Handle(GetArenaRankingQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetArenaRankingAsync(request.Ranking);
        }
    }
}
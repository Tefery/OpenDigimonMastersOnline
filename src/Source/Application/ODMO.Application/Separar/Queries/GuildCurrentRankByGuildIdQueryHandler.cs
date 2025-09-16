using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GuildCurrentRankByGuildIdQueryHandler : IRequestHandler<GuildCurrentRankByGuildIdQuery, short>
    {
        private readonly IServerQueriesRepository _repository;

        public GuildCurrentRankByGuildIdQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<short> Handle(GuildCurrentRankByGuildIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetGuildRankByGuildIdAsync(request.GuildId);
        }
    }
}
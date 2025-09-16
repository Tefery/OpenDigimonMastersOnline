using ODMO.Commons.DTOs.Mechanics;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GuildByGuildNameQueryHandler : IRequestHandler<GuildByGuildNameQuery, GuildDTO?>
    {
        private readonly IServerQueriesRepository _repository;

        public GuildByGuildNameQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GuildDTO?> Handle(GuildByGuildNameQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetGuildByGuildNameAsync(request.GuildName);
        }
    }
}
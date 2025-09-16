using ODMO.Commons.DTOs.Mechanics;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GuildByIdQueryHandler : IRequestHandler<GuildByIdQuery, GuildDTO?>
    {
        private readonly IServerQueriesRepository _repository;

        public GuildByIdQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GuildDTO?> Handle(GuildByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetGuildByIdAsync(request.GuildId);
        }
    }
}
using ODMO.Commons.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ODMO.Application.Separar.Queries
{
    public class GetCharacterNameAndGuildByIdQueryHandler : IRequestHandler<GetCharacterNameAndGuildByIdQuery, (string TamerName, string GuildName)>
    {
        private readonly ICharacterQueriesRepository _repository;

        public GetCharacterNameAndGuildByIdQueryHandler(ICharacterQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<(string TamerName, string GuildName)> Handle(GetCharacterNameAndGuildByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCharacterNameAndGuildByIdQAsync(request.CharacterId);
        }
    }
}

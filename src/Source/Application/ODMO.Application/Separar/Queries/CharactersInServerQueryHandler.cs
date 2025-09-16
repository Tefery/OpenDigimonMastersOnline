using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class CharactersInServerQueryHandler : IRequestHandler<CharactersInServerQuery, byte>
    {
        private readonly IServerQueriesRepository _repository;

        public CharactersInServerQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<byte> Handle(CharactersInServerQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCharacterInServerAsync(request.AccountId, request.ServerId);
        }
    }
}

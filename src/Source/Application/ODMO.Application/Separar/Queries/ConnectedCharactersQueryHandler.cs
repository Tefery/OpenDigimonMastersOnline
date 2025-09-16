using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class ConnectedCharactersQueryHandler : IRequestHandler<ConnectedCharactersQuery, IList<CharacterDTO>>
    {
        private readonly IAccountQueriesRepository _repository;

        public ConnectedCharactersQueryHandler(IAccountQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<CharacterDTO>> Handle(ConnectedCharactersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetConnectedCharactersAsync();
        }
    }
}

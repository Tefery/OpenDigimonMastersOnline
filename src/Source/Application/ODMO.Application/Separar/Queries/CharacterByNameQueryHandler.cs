using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class CharacterByNameQueryHandler : IRequestHandler<CharacterByNameQuery, CharacterDTO?>
    {
        private readonly ICharacterQueriesRepository _repository;

        public CharacterByNameQueryHandler(ICharacterQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<CharacterDTO?> Handle(CharacterByNameQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCharacterByNameAsync(request.CharacterName);
        }
    }
}
using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class CharacterByIdQueryHandler : IRequestHandler<CharacterByIdQuery, CharacterDTO?>
    {
        private readonly ICharacterQueriesRepository _repository;

        public CharacterByIdQueryHandler(ICharacterQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<CharacterDTO?> Handle(CharacterByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCharacterByIdAsync(request.CharacterId);
        }
    }
}

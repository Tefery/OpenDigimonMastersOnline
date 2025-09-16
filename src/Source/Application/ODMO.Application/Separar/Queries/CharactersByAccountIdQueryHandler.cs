using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class CharactersByAccountIdQueryHandler : IRequestHandler<CharactersByAccountIdQuery, IList<CharacterDTO>>
    {
        private readonly ICharacterQueriesRepository _repository;

        public CharactersByAccountIdQueryHandler(ICharacterQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<CharacterDTO>> Handle(CharactersByAccountIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCharactersByAccountIdAsync(request.AccountId);
        }
    }
}

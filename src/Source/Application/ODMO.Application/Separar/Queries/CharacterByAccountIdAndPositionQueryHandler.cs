using MediatR;
using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Interfaces;

namespace ODMO.Application.Separar.Queries
{
    public class CharacterByAccountIdAndPositionQueryHandler : IRequestHandler<CharacterByAccountIdAndPositionQuery, CharacterDTO?>
    {
        private readonly ICharacterQueriesRepository _repository;

        public CharacterByAccountIdAndPositionQueryHandler(ICharacterQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<CharacterDTO?> Handle(CharacterByAccountIdAndPositionQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCharacterByAccountIdAndPositionAsync(request.AccountId, request.Position);
        }
    }
}

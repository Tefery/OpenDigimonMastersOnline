using MediatR;
using ODMO.Commons.DTOs.Character;

namespace ODMO.Application.Separar.Queries
{
    public class CharacterAndItemsByIdQuery : IRequest<CharacterDTO?>
    {
        public long CharacterId { get; set; }

        public CharacterAndItemsByIdQuery(long characterId)
        {
            CharacterId = characterId;
        }
    }
}


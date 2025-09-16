using MediatR;
using ODMO.Commons.DTOs.Character;

namespace ODMO.Application.Separar.Queries
{
    public class CharacterByIdQuery : IRequest<CharacterDTO?>
    {
        public long CharacterId { get; set; }

        public CharacterByIdQuery(long characterId)
        {
            CharacterId = characterId;
        }
    }
}


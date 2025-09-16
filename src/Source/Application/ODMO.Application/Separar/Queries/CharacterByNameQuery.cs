using MediatR;
using ODMO.Commons.DTOs.Character;

namespace ODMO.Application.Separar.Queries
{
    public class CharacterByNameQuery : IRequest<CharacterDTO?>
    {
        public string CharacterName { get; set; }

        public CharacterByNameQuery(string characterName)
        {
            CharacterName = characterName;
        }
    }
}


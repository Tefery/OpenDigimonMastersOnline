using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Models.Character;
using MediatR;

namespace ODMO.Application.Separar.Commands.Create
{
    public class CreateCharacterEncyclopediaCommand : IRequest<CharacterEncyclopediaModel>
    {
        public CharacterEncyclopediaModel CharacterEncyclopedia { get; set; }

        public CreateCharacterEncyclopediaCommand(CharacterEncyclopediaModel characterEncyclopedia)
        {
            CharacterEncyclopedia = characterEncyclopedia;
        }
    }
}

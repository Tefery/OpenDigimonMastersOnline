using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Models.Events;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterEncyclopediaCommand : IRequest
    {
        public CharacterEncyclopediaModel CharacterEncyclopedia { get; set; }

        public UpdateCharacterEncyclopediaCommand(CharacterEncyclopediaModel characterEncyclopedia)
        {
            CharacterEncyclopedia = characterEncyclopedia;
        }
    }
}

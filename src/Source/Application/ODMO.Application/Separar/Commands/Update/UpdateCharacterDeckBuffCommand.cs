using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Models.Events;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterDeckBuffCommand : IRequest
    {
        public CharacterModel Character { get; set; }

        public UpdateCharacterDeckBuffCommand(CharacterModel character)
        {
            Character = character;
        }
    }
}

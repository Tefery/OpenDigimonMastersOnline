using ODMO.Commons.Models.Character;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterLocationCommand : IRequest
    {
        public CharacterLocationModel Location { get; set; }

        public UpdateCharacterLocationCommand(CharacterLocationModel location)
        {
            Location = location;
        }
    }
}
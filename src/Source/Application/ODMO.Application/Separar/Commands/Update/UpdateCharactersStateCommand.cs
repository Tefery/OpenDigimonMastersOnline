using ODMO.Commons.Enums.Character;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharactersStateCommand : IRequest
    {
        public CharacterStateEnum State { get; set; }

        public UpdateCharactersStateCommand(CharacterStateEnum state)
        {
            State = state;
        }
    }
}
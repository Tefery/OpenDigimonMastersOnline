using ODMO.Commons.Models.Character;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterProgressCompleteCommand : IRequest
    {
        public CharacterProgressModel Progress { get; set; }

        public UpdateCharacterProgressCompleteCommand(CharacterProgressModel progress)
        {
            Progress = progress;
        }
    }
}
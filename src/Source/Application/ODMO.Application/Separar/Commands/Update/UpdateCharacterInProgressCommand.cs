using ODMO.Commons.Models.Character;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateCharacterInProgressCommand : IRequest
    {
        public InProgressQuestModel Progress { get; set; }

        public UpdateCharacterInProgressCommand(InProgressQuestModel progress)
        {
            Progress = progress;
        }
    }
}
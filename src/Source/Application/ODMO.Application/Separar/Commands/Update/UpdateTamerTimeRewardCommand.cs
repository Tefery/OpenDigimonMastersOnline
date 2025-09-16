using ODMO.Commons.Models.Events;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateTamerTimeRewardCommand : IRequest
    {

        public TimeRewardModel TimeRewardModel { get; set; }

        public UpdateTamerTimeRewardCommand(TimeRewardModel timeReward)
        {
            TimeRewardModel = timeReward;
        }
    }
}

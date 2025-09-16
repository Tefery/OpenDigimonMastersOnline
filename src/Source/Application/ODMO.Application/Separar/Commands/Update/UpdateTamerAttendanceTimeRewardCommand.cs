using ODMO.Commons.Models.Events;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateTamerAttendanceTimeRewardCommand : IRequest
    {
        public TimeRewardModel TimeRewardModel { get; set; }

        public UpdateTamerAttendanceTimeRewardCommand(TimeRewardModel timeReward)
        {
            TimeRewardModel = timeReward;
        }
    }
}

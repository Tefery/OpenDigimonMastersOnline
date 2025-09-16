using ODMO.Commons.DTOs.Character;
using ODMO.Commons.DTOs.Events;
using ODMO.Commons.Enums;
using ODMO.Commons.Models.Events;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateTamerAttendanceRewardCommand: IRequest
    {
    
        public AttendanceRewardModel AttendanceRewardModel { get; set; }

        public UpdateTamerAttendanceRewardCommand(AttendanceRewardModel attendanceReward)
        {
            AttendanceRewardModel = attendanceReward;
        }
    }
}

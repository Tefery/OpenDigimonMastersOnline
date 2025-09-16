using MediatR;
using ODMO.Commons.DTOs.Events;

namespace ODMO.Application.Separar.Queries
{
    public class TamerAttendanceQuery : IRequest<AttendanceRewardDTO>
    {
        public long CharacterId { get; set; }

        public TamerAttendanceQuery(long characterId)
        {
            CharacterId = characterId;
        }
    }
}
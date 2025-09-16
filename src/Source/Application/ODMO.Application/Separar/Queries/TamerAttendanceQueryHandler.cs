using ODMO.Commons.DTOs.Events;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class TamerAttendanceQueryHandler : IRequestHandler<TamerAttendanceQuery, AttendanceRewardDTO>
    {
        private readonly IServerQueriesRepository _repository;

        public TamerAttendanceQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<AttendanceRewardDTO> Handle(TamerAttendanceQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetTamerAttendanceAsync(request.CharacterId);
        }
    }
}
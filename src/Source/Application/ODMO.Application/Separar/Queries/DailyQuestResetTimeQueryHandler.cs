using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class DailyQuestResetTimeQueryHandler : IRequestHandler<DailyQuestResetTimeQuery, DateTime>
    {
        private readonly IServerQueriesRepository _repository;

        public DailyQuestResetTimeQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<DateTime> Handle(DailyQuestResetTimeQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetDailyQuestResetTimeAsync();
        }
    }
}
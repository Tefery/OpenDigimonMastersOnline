using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class EventsConfigQueryHandler : IRequestHandler<EventsConfigQuery, List<EventConfigDTO>>
    {
        private readonly IConfigQueriesRepository _repository;

        public EventsConfigQueryHandler(IConfigQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<EventConfigDTO>> Handle(EventsConfigQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetEventsConfigAsync(request.IsEnabled);
        }
    }
}
using MediatR;
using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;

namespace ODMO.Application.Separar.Queries
{
    public class EventsConfigQuery : IRequest<List<EventConfigDTO>>
    {
        public bool IsEnabled { get; private set; }

        public EventsConfigQuery(bool isEnabled = true)
        {
            IsEnabled = isEnabled;
        }
    }
}
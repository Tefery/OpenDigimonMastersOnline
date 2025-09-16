using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateEventConfigCommand : IRequest<EventConfigDTO>
    {
        public EventConfigDTO Event { get; }

        public CreateEventConfigCommand(EventConfigDTO eventConfig)
        {
            Event = eventConfig;
        }
    }
}
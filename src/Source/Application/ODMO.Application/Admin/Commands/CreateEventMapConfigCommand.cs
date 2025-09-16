using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateEventMapConfigCommand : IRequest<EventMapsConfigDTO>
    {
        public EventMapsConfigDTO EventMap { get; }

        public CreateEventMapConfigCommand(EventMapsConfigDTO eventMapConfig)
        {
            EventMap = eventMapConfig;
        }
    }
}
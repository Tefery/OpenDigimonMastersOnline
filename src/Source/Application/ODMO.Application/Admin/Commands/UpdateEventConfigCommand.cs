using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class UpdateEventConfigCommand : IRequest
    {
        public EventConfigDTO Event { get; }

        public UpdateEventConfigCommand(EventConfigDTO eventConfig)
        {
            Event = eventConfig;
        }
    }
}
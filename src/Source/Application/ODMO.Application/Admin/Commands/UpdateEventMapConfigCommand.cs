using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class UpdateEventMapConfigCommand : IRequest
    {
        public EventMapsConfigDTO EventMap { get; }

        public UpdateEventMapConfigCommand(EventMapsConfigDTO eventMapConfig)
        {
            EventMap = eventMapConfig;
        }
    }
}
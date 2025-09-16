using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateEventMobCommand : IRequest<EventMobConfigDTO>
    {
        public EventMobConfigDTO Mob { get; }

        public CreateEventMobCommand(EventMobConfigDTO mob)
        {
            Mob = mob;
        }
    }
}
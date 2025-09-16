using ODMO.Commons.DTOs.Config;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateMobCommand : IRequest<MobConfigDTO>
    {
        public MobConfigDTO Mob { get; }

        public CreateMobCommand(MobConfigDTO mob)
        {
            Mob = mob;
        }
    }
}
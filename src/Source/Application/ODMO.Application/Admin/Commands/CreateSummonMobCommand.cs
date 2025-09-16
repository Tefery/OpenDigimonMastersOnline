using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateSummonMobCommand : IRequest<SummonMobDTO>
    {
        public SummonMobDTO Mob { get; }

        public CreateSummonMobCommand(SummonMobDTO mob)
        {
            Mob = mob;
        }
    }
}
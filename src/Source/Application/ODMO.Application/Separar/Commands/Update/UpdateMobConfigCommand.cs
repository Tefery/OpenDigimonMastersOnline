using ODMO.Commons.Models.Config;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateMobConfigCommand : IRequest
    {
        public MobConfigModel MobConfig { get; set; }

        public UpdateMobConfigCommand(MobConfigModel mobConfig)
        {
            MobConfig = mobConfig;
        }
    }
}

using ODMO.Commons.Models.Config;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateMapConfigCommand : IRequest
    {
        public MapConfigModel MapConfig { get; set; }

        public UpdateMapConfigCommand(MapConfigModel mapConfig)
        {
            MapConfig = mapConfig;
        }
    }
}

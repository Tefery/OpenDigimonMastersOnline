using ODMO.Commons.DTOs.Config;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class UpdateHatchConfigCommand : IRequest
    {
        public HatchConfigDTO Hatch { get; }

        public UpdateHatchConfigCommand(HatchConfigDTO hatch)
        {
            Hatch = hatch;
        }
    }
}
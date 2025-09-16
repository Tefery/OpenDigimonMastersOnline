using ODMO.Commons.DTOs.Config;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateHatchConfigCommand : IRequest<HatchConfigDTO>
    {
        public HatchConfigDTO Hatch { get; }

        public CreateHatchConfigCommand(HatchConfigDTO hatch)
        {
            Hatch = hatch;
        }
    }
}
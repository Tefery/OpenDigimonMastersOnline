using ODMO.Commons.DTOs.Config;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateCloneConfigCommand : IRequest<CloneConfigDTO>
    {
        public CloneConfigDTO Clone { get; }

        public CreateCloneConfigCommand(CloneConfigDTO clone)
        {
            Clone = clone;
        }
    }
}
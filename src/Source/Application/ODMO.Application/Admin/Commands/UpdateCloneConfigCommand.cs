using ODMO.Commons.DTOs.Config;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class UpdateCloneConfigCommand : IRequest
    {
        public CloneConfigDTO Clone { get; }

        public UpdateCloneConfigCommand(CloneConfigDTO clone)
        {
            Clone = clone;
        }
    }
}
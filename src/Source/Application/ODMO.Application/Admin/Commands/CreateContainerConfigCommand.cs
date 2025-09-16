using ODMO.Commons.DTOs.Assets;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateContainerConfigCommand : IRequest<ContainerAssetDTO>
    {
        public ContainerAssetDTO Container { get; }

        public CreateContainerConfigCommand(ContainerAssetDTO container)
        {
            Container = container;
        }
    }
}
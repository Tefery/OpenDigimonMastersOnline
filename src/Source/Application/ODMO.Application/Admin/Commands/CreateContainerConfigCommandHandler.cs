using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateContainerConfigCommandHandler : IRequestHandler<CreateContainerConfigCommand, ContainerAssetDTO>
    {
        private readonly IAdminCommandsRepository _repository;

        public CreateContainerConfigCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContainerAssetDTO> Handle(CreateContainerConfigCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddContainerConfigAsync(request.Container);
        }
    }
}
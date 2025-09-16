using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateCloneConfigCommandHandler : IRequestHandler<CreateCloneConfigCommand, CloneConfigDTO>
    {
        private readonly IAdminCommandsRepository _repository;

        public CreateCloneConfigCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<CloneConfigDTO> Handle(CreateCloneConfigCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddCloneConfigAsync(request.Clone);
        }
    }
}
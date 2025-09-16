using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateHatchConfigCommandHandler : IRequestHandler<CreateHatchConfigCommand, HatchConfigDTO>
    {
        private readonly IAdminCommandsRepository _repository;

        public CreateHatchConfigCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<HatchConfigDTO> Handle(CreateHatchConfigCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddHatchConfigAsync(request.Hatch);
        }
    }
}
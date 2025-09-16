using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateScanConfigCommandHandler : IRequestHandler<CreateScanConfigCommand, ScanDetailAssetDTO>
    {
        private readonly IAdminCommandsRepository _repository;

        public CreateScanConfigCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ScanDetailAssetDTO> Handle(CreateScanConfigCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddScanConfigAsync(request.Scan);
        }
    }
}
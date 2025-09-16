using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class UpdateScanConfigCommandHandler : IRequestHandler<UpdateScanConfigCommand>
    {
        private readonly IAdminCommandsRepository _repository;

        public UpdateScanConfigCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateScanConfigCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateScanConfigAsync(request.Scan);

            return Unit.Value;
        }
    }
}
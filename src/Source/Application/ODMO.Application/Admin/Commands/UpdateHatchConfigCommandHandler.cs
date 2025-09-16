using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class UpdateHatchConfigCommandHandler : IRequestHandler<UpdateHatchConfigCommand>
    {
        private readonly IAdminCommandsRepository _repository;

        public UpdateHatchConfigCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateHatchConfigCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateHatchConfigAsync(request.Hatch);

            return Unit.Value;
        }
    }
}
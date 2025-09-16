using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class DeleteHatchConfigCommandHandler : IRequestHandler<DeleteHatchConfigCommand>
    {
        private readonly IAdminCommandsRepository _repository;

        public DeleteHatchConfigCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteHatchConfigCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteHatchConfigAsync(request.Id);

            return Unit.Value;
        }
    }
}
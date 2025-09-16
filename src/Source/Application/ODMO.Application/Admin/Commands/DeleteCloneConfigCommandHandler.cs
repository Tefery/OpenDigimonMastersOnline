using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class DeleteCloneConfigCommandHandler : IRequestHandler<DeleteCloneConfigCommand>
    {
        private readonly IAdminCommandsRepository _repository;

        public DeleteCloneConfigCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteCloneConfigCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteCloneConfigAsync(request.Id);

            return Unit.Value;
        }
    }
}
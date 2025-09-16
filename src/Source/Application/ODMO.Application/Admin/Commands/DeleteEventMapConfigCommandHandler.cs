using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class DeleteEventMapConfigCommandHandler : IRequestHandler<DeleteEventMapConfigCommand>
    {
        private readonly IAdminCommandsRepository _repository;

        public DeleteEventMapConfigCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteEventMapConfigCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteEventMapConfigAsync(request.Id);

            return Unit.Value;
        }
    }
}
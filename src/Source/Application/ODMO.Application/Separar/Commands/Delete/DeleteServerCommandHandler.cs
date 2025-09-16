using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Commands.Delete
{
    public class DeleteServerCommandHandler : IRequestHandler<DeleteServerCommand, bool>
    {
        private readonly IServerCommandsRepository _repository;

        public DeleteServerCommandHandler(IServerCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(DeleteServerCommand request, CancellationToken cancellationToken)
        {
            return await _repository.DeleteServerAsync(request.Id);
        }
    }
}
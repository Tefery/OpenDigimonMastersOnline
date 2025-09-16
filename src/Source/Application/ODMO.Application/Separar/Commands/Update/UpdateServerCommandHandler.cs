using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateServerCommandHandler : IRequestHandler<UpdateServerCommand>
    {
        private readonly IServerCommandsRepository _repository;

        public UpdateServerCommandHandler(IServerCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateServerCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateServerAsync(request.ServerId,
                request.Name,
                request.Experience,
                request.Maintenance);

            return Unit.Value;
        }
    }
}

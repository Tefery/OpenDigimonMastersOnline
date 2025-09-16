using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Commands.Update
{
    public class UpdateAdminUserCommandHandler : IRequestHandler<UpdateAdminUserCommand>
    {
        private readonly IConfigCommandsRepository _repository;

        public UpdateAdminUserCommandHandler(IConfigCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateAdminUserCommand request, CancellationToken cancellationToken)
        {
            await _repository.UpdateAdminUserAsync(request.User);

            return Unit.Value;
        }
    }
}
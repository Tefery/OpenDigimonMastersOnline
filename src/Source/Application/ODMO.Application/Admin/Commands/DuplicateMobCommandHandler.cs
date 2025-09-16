using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class DuplicateMobCommandHandler : IRequestHandler<DuplicateMobCommand>
    {
        private readonly IAdminCommandsRepository _repository;

        public DuplicateMobCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DuplicateMobCommand request, CancellationToken cancellationToken)
        {
            await _repository.DuplicateMobAsync(request.Id);

            return Unit.Value;
        }
    }
}
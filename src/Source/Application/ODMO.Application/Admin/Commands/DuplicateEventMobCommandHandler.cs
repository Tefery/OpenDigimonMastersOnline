using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class DuplicateEventMobCommandHandler : IRequestHandler<DuplicateEventMobCommand>
    {
        private readonly IAdminCommandsRepository _repository;

        public DuplicateEventMobCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DuplicateEventMobCommand request, CancellationToken cancellationToken)
        {
            await _repository.DuplicateEventMobAsync(request.Id);

            return Unit.Value;
        }
    }
}
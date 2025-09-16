using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateEventMobCommandHandler : IRequestHandler<CreateEventMobCommand, EventMobConfigDTO>
    {
        private readonly IAdminCommandsRepository _repository;

        public CreateEventMobCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<EventMobConfigDTO> Handle(CreateEventMobCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddEventMobAsync(request.Mob);
        }
    }
}
using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateEventConfigCommandHandler : IRequestHandler<CreateEventConfigCommand, EventConfigDTO>
    {
        private readonly IAdminCommandsRepository _repository;

        public CreateEventConfigCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<EventConfigDTO> Handle(CreateEventConfigCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddEventConfigAsync(request.Event);
        }
    }
}
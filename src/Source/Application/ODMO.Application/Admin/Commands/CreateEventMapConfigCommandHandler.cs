using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateEventMapConfigCommandHandler : IRequestHandler<CreateEventMapConfigCommand, EventMapsConfigDTO>
    {
        private readonly IAdminCommandsRepository _repository;

        public CreateEventMapConfigCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<EventMapsConfigDTO> Handle(CreateEventMapConfigCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddEventMapConfigAsync(request.EventMap);
        }
    }
}
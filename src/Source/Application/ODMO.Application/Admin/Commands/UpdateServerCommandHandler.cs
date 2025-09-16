using ODMO.Commons.DTOs.Server;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class UpdateServerCommandHandler : IRequestHandler<UpdateServerCommand>
    {
        private readonly IAdminCommandsRepository _repository;

        public UpdateServerCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateServerCommand request, CancellationToken cancellationToken)
        {
            var dto = new ServerDTO()
            {
                Id = request.Id,
                Name = request.Name,
                Experience = request.Experience,
                Maintenance = request.Maintenance,
                Type = request.Type,
                Port = request.Port
            };

            await _repository.UpdateServerAsync(dto);

            return Unit.Value;
        }
    }
}
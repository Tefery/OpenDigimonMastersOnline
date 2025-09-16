using ODMO.Commons.DTOs.Server;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateServerCommandHandler : IRequestHandler<CreateServerCommand, ServerDTO>
    {
        private readonly IAdminCommandsRepository _repository;

        public CreateServerCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServerDTO> Handle(CreateServerCommand request, CancellationToken cancellationToken)
        {
            var dto = new ServerDTO()
            {
                Name = request.Name,
                Experience = request.Experience,
                New = true,
                Maintenance = true,
                CreateDate = DateTime.Now,
                Overload = ServerOverloadEnum.Empty,
                Type = request.Type,
                Port = request.Port
            };

            return await _repository.AddServerAsync(dto);
        }
    }
}
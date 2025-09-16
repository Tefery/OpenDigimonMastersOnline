using ODMO.Commons.DTOs.Account;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Account;
using MediatR;

namespace ODMO.Application.Separar.Commands.Create
{
    public class CreateSystemInformationCommandHandler : IRequestHandler<CreateSystemInformationCommand, SystemInformationDTO>
    {
        private readonly IAccountCommandsRepository _repository;

        public CreateSystemInformationCommandHandler(IAccountCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<SystemInformationDTO> Handle(CreateSystemInformationCommand request, CancellationToken cancellationToken)
        {
            var systemInformation = new SystemInformationModel(request.AccountId, request.Cpu, request.Gpu, request.Ip);

            return await _repository.AddSystemInformationAsync(systemInformation);
        }
    }
}

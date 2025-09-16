using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class CreateSummonMobCommandHandler : IRequestHandler<CreateSummonMobCommand,SummonMobDTO>
    {
        private readonly IAdminCommandsRepository _repository;

        public CreateSummonMobCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<SummonMobDTO> Handle(CreateSummonMobCommand request, CancellationToken cancellationToken)
        {
            return await _repository.AddSummonMobAsync(request.Mob);
        }
    }
}
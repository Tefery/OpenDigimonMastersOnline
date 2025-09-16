using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Repositories.Admin;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ODMO.Application.Admin.Commands
{
    public class UpdateSummonCommandHandler :IRequestHandler<CreateSummonCommand,SummonDTO>
    {
        private readonly IAdminCommandsRepository _repository;

        public UpdateSummonCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<SummonDTO> Handle(CreateSummonCommand request,CancellationToken cancellationToken)
        {
            return await _repository.AddSummonConfigAsync(request.Summon);
        }
    }
}

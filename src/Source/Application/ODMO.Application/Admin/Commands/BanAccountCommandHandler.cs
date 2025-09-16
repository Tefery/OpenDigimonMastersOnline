using ODMO.Commons.DTOs.Account;
using ODMO.Commons.Repositories.Admin;
using MediatR;

namespace ODMO.Application.Admin.Commands
{
    public class BanAccountCommandHandler : IRequestHandler<BanAccountCommand>
    {
        private readonly IAdminCommandsRepository _repository;

        public BanAccountCommandHandler(IAdminCommandsRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(BanAccountCommand request, CancellationToken cancellationToken)
        {
            var accountBlock = new AccountBlockDTO
            {
                AccountId = request.AccountId,
                Type = request.Type,
                Reason = request.Reason,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            };

            await _repository.AddAccountBlockAsync(accountBlock);

            return Unit.Value;
        }
    }
}

using ODMO.Commons.DTOs.Account;
using ODMO.Commons.Enums.Account;
using ODMO.Commons.Interfaces;
using ODMO.Commons.Models.Account;
using MediatR;

namespace ODMO.Application.Separar.Commands.Create
{
    public class AddAccountBlockCommandHandler : IRequestHandler<AddAccountBlockCommand, AccountBlockDTO>
    {
        private readonly IAccountCommandsRepository _repository;

        public AddAccountBlockCommandHandler(IAccountCommandsRepository repository)
        {
            _repository = repository;
        }
        
        public async Task<AccountBlockDTO> Handle(AddAccountBlockCommand request, CancellationToken cancellationToken)
        {
            var accountBLock = await Task.FromResult(new AccountBlockModel
            {
                AccountId = request.AccountId,
                Type = request.Type,
                Reason = request.Reason,
                StartDate = request.StartDate,
                EndDate = request.EndDate
            });
            return await _repository.AddAccountBlockAsync(accountBLock);
        }
    }
}
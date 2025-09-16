using ODMO.Commons.DTOs.Account;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class AccountByUsernameQueryHandler : IRequestHandler<AccountByUsernameQuery, AccountDTO?>
    {
        private readonly IAccountQueriesRepository _repository;

        public AccountByUsernameQueryHandler(IAccountQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<AccountDTO?> Handle(AccountByUsernameQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAccountByUsernameAsync(request.Username);
        }
    }
}

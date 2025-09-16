using ODMO.Commons.DTOs.Account;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class AccountByIdQueryHandler : IRequestHandler<AccountByIdQuery, AccountDTO?>
    {
        private readonly IAccountQueriesRepository _repository;

        public AccountByIdQueryHandler(IAccountQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<AccountDTO?> Handle(AccountByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAccountByIdAsync(request.Id);
        }
    }
}

using ODMO.Commons.DTOs.Account;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class AccountBlockByIdQueryHandler : IRequestHandler<AccountBlockByIdQuery, AccountBlockDTO?>
    {
        private readonly IAccountQueriesRepository _repository;

        public AccountBlockByIdQueryHandler(IAccountQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<AccountBlockDTO?> Handle(AccountBlockByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAccountBlockByIdAsync(request.Id);
        }
    }
}

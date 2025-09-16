using ODMO.Commons.DTOs.Account;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class AllAccountsQueryHandler : IRequestHandler<AllAccountsQuery, IList<AccountDTO>>
    {
        private readonly IAccountQueriesRepository _repository;

        public AllAccountsQueryHandler(IAccountQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<AccountDTO>> Handle(AllAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllAccountsAsync();
        }
    }
}

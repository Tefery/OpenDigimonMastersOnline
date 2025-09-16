using ODMO.Commons.DTOs.Account;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries;

public class CreateGameAccountQueryHandler : IRequestHandler<CreateGameAccountQuery, AccountDTO>
{
    private readonly IAccountQueriesRepository _accountQueriesRepository;

    public CreateGameAccountQueryHandler(IAccountQueriesRepository accountQueriesRepository)
    {
        _accountQueriesRepository = accountQueriesRepository;
    }

    public async Task<AccountDTO> Handle(CreateGameAccountQuery request, CancellationToken cancellationToken)
    {
        return await _accountQueriesRepository.CreateGameAccountAsync(request.Username, request.Password);
    }
}
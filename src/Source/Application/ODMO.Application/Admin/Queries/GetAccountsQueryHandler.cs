using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetAccountsQueryHandler : IRequestHandler<GetAccountsQuery, GetAccountsQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetAccountsQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAccountsQueryDto> Handle(GetAccountsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAccountsAsync(request.Limit, request.Offset, request.SortColumn, request.SortDirection, request.Filter);
        }
    }
}
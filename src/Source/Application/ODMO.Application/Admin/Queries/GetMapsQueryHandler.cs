using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetMapsQueryHandler : IRequestHandler<GetMapsQuery, GetMapsQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetMapsQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetMapsQueryDto> Handle(GetMapsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMapsAsync(request.Limit, request.Offset, request.SortColumn, request.SortDirection, request.Filter);
        }
    }
}
using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetRaidsQueryHandler : IRequestHandler<GetRaidsQuery, GetRaidsQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetRaidsQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetRaidsQueryDto> Handle(GetRaidsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetRaidsAsync(request.MapId, request.Limit, request.Offset, request.SortColumn, request.SortDirection, request.Filter);
        }
    }
}
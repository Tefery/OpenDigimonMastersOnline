using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetHatchConfigsQueryHandler : IRequestHandler<GetHatchConfigsQuery, GetHatchConfigsQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetHatchConfigsQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetHatchConfigsQueryDto> Handle(GetHatchConfigsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetHatchConfigsAsync(request.Limit, request.Offset, request.SortColumn, request.SortDirection, request.Filter);
        }
    }
}
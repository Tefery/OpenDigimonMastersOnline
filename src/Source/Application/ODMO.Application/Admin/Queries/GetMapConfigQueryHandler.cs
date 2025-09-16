using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetMapConfigQueryHandler : IRequestHandler<GetMapConfigQuery, GetMapConfigQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetMapConfigQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetMapConfigQueryDto> Handle(GetMapConfigQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMapConfigAsync(request.Filter);
        }
    }
}
using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetMapByIdQueryHandler : IRequestHandler<GetMapByIdQuery, GetMapByIdQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetMapByIdQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetMapByIdQueryDto> Handle(GetMapByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMapByIdAsync(request.Id);
        }
    }
}
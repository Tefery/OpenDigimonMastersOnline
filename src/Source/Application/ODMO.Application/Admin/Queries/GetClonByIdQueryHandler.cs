using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetClonByIdQueryHandler : IRequestHandler<GetClonByIdQuery, GetClonByIdQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetClonByIdQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetClonByIdQueryDto> Handle(GetClonByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetClonByIdAsync(request.Id);
        }
    }
}
using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetSpawnPointByIdQueryHandler : IRequestHandler<GetSpawnPointByIdQuery, GetSpawnPointByIdQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetSpawnPointByIdQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSpawnPointByIdQueryDto> Handle(GetSpawnPointByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSpawnPointByIdAsync(request.Id);
        }
    }
}
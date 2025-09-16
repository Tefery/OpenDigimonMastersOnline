using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetMobAssetQueryHandler : IRequestHandler<GetMobAssetQuery, GetMobAssetQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetMobAssetQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetMobAssetQueryDto> Handle(GetMobAssetQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMobAssetAsync(request.Filter);
        }
    }
}
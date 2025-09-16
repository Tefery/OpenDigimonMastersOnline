using MediatR;
using ODMO.Application.Admin.Repositories;

namespace ODMO.Application.Admin.Queries
{
    public class GetSummonMobAssetQueryHandler : IRequestHandler<GetSummonMobAssetQuery,GetSummonMobAssetQueryDto>
    {
        private readonly IAdminQueriesRepository _repository;

        public GetSummonMobAssetQueryHandler(IAdminQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetSummonMobAssetQueryDto> Handle(GetSummonMobAssetQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSummonMobAssetAsync(request.Filter);
        }
    }
}
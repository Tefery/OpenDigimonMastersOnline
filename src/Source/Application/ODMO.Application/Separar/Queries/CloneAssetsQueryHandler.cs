using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class CloneAssetsQueryHandler : IRequestHandler<CloneAssetsQuery, List<CloneAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public CloneAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CloneAssetDTO>> Handle(CloneAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCloneAssetsAsync();
        }
    }
}
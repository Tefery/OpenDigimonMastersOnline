using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class CloneValueAssetsQueryHandler : IRequestHandler<CloneValueAssetsQuery, List<CloneValueAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public CloneValueAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CloneValueAssetDTO>> Handle(CloneValueAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCloneValueAssetsAsync();
        }
    }
}
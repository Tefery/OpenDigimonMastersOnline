using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class SealStatusAssetsQueryHandler : IRequestHandler<SealStatusAssetsQuery, List<SealDetailAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public SealStatusAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SealDetailAssetDTO>> Handle(SealStatusAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSealStatusAssetsAsync();
        }
    }
}
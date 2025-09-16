using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class ScanDetailAssetQueryHandler : IRequestHandler<ScanDetailAssetQuery, List<ScanDetailAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public ScanDetailAssetQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ScanDetailAssetDTO>> Handle(ScanDetailAssetQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetScanDetailAssetsAsync();
        }
    }
}
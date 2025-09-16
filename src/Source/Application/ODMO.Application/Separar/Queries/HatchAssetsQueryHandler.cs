using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class HatchAssetsQueryHandler : IRequestHandler<HatchAssetsQuery, List<HatchAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public HatchAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<HatchAssetDTO>> Handle(HatchAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetHatchAssetsAsync();
        }
    }
}
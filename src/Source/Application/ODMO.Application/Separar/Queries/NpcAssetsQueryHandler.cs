using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class NpcAssetsQueryHandler : IRequestHandler<NpcAssetsQuery, List<NpcAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public NpcAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<NpcAssetDTO>> Handle(NpcAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetNpcAssetsAsync();
        }
    }
}
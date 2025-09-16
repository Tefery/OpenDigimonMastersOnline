using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class BuffInfoAssetsQueryHandler : IRequestHandler<BuffInfoAssetsQuery, List<BuffAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public BuffInfoAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<BuffAssetDTO>> Handle(BuffInfoAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetBuffInfoAssetsAsync();
        }
    }
}
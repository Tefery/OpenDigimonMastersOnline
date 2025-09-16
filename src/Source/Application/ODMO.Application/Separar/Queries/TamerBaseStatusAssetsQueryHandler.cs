using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class TamerBaseStatusAssetsQueryHandler : IRequestHandler<TamerBaseStatusAssetsQuery, List<CharacterBaseStatusAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public TamerBaseStatusAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CharacterBaseStatusAssetDTO>> Handle(TamerBaseStatusAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllTamerBaseStatusAsync();
        }
    }
}
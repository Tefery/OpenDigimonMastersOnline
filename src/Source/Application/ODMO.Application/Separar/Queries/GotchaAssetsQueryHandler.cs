using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GotchaAssetsQueryHandler : IRequestHandler<GotchaAssetsQuery, List<GotchaAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public GotchaAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GotchaAssetDTO>> Handle(GotchaAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetGotchaAssetsAsync();
        }
    }
}

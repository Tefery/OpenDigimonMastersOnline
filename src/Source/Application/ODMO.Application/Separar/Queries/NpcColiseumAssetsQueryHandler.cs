using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class NpcColiseumAssetsQueryHandler : IRequestHandler<NpcColiseumAssetsQuery, List<NpcColiseumAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public NpcColiseumAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<NpcColiseumAssetDTO>> Handle(NpcColiseumAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetNpcColiseumAssetsAsync();
        }
    }
}
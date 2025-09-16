using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class AllTitleStatusAssetsQueryHandler : IRequestHandler<AllTitleStatusAssetsQuery, List<TitleStatusAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public AllTitleStatusAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<TitleStatusAssetDTO>> Handle(AllTitleStatusAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllTitleStatusInfoAsync();
        }
    }
}

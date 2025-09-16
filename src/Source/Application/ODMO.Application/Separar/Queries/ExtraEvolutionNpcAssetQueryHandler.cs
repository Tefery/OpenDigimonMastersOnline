using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class ExtraEvolutionNpcAssetQueryHandler : IRequestHandler<ExtraEvolutionNpcAssetQuery, List<ExtraEvolutionNpcAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public ExtraEvolutionNpcAssetQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<ExtraEvolutionNpcAssetDTO>> Handle(ExtraEvolutionNpcAssetQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetExtraEvolutionNpcAssetAsync();
        }
    }
}

using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class MonthlyEventAssetsQueryHandler : IRequestHandler<MonthlyEventAssetsQuery, List<MonthlyEventAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public MonthlyEventAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<MonthlyEventAssetDTO>> Handle(MonthlyEventAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMonthlyEventAssetsAsync();
        }
    }
}
using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class SummonAssetsQueryHandler : IRequestHandler<SummonAssetsQuery, List<SummonDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public SummonAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<SummonDTO>> Handle(SummonAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetSummonAssetsAsync();
        }
    }
}

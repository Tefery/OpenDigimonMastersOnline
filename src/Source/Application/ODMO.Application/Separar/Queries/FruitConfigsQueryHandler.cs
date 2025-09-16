using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class FruitConfigsQueryHandler : IRequestHandler<FruitConfigsQuery, List<FruitConfigDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public FruitConfigsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<FruitConfigDTO>> Handle(FruitConfigsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetFruitConfigsAsync();
        }
    }
}
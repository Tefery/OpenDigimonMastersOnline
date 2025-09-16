using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class StatusApplyAssetQueryHandler : IRequestHandler<StatusApplyAssetQuery, List<StatusApplyAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public StatusApplyAssetQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<StatusApplyAssetDTO>> Handle(StatusApplyAssetQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetStatusApplyInfoAsync();
        }
    }
}

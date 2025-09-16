using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class PortalAssetsQueryHandler : IRequestHandler<PortalAssetsQuery, List<PortalAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public PortalAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<PortalAssetDTO>> Handle(PortalAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetPortalAssetsAsync();
        }
    }
}

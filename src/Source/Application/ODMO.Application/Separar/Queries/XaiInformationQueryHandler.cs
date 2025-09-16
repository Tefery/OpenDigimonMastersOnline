using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class XaiInformationQueryHandler : IRequestHandler<XaiInformationQuery, XaiAssetDTO>
    {
        private readonly IServerQueriesRepository _repository;

        public XaiInformationQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<XaiAssetDTO> Handle(XaiInformationQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetXaiInformationAsync(request.ItemId);
        }
    }
}
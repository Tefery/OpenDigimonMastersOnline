using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class AllDigimonBaseInfoQueryHandler : IRequestHandler<AllDigimonBaseInfoQuery, IList<DigimonBaseInfoAssetDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public AllDigimonBaseInfoQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<DigimonBaseInfoAssetDTO>> Handle(AllDigimonBaseInfoQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAllDigimonBaseInfoAsync();
        }
    }
}

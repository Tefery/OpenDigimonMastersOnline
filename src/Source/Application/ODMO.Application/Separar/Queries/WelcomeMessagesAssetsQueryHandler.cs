using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class WelcomeMessagesAssetsQueryHandler : IRequestHandler<WelcomeMessagesAssetsQuery, List<WelcomeMessageConfigDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public WelcomeMessagesAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<WelcomeMessageConfigDTO>> Handle(WelcomeMessagesAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetWelcomeMessagesAssetsAsync();
        }
    }
}
using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class ActiveWelcomeMessagesAssetsQueryHandler : IRequestHandler<ActiveWelcomeMessagesAssetsQuery, List<WelcomeMessageConfigDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public ActiveWelcomeMessagesAssetsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<WelcomeMessageConfigDTO>> Handle(ActiveWelcomeMessagesAssetsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetActiveWelcomeMessagesAssetsAsync();
        }
    }
}
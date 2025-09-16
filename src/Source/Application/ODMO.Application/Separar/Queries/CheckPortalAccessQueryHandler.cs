using ODMO.Commons.Enums;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class CheckPortalAccessQueryHandler : IRequestHandler<CheckPortalAccessQuery, UserAccessLevelEnum>
    {
        private readonly IServerQueriesRepository _repository;

        public CheckPortalAccessQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserAccessLevelEnum> Handle(CheckPortalAccessQuery request, CancellationToken cancellationToken)
        {
            return await _repository.CheckPortalAccessAsync(request.Username, request.Password);
        }
    }
}

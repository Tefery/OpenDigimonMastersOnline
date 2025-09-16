using ODMO.Commons.Enums;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GetAdminAccessLevelQueryHandler : IRequestHandler<GetAdminAccessLevelQuery, UserAccessLevelEnum>
    {
        private readonly IServerQueriesRepository _repository;

        public GetAdminAccessLevelQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserAccessLevelEnum> Handle(GetAdminAccessLevelQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAdminAccessLevelAsync(request.Username);
        }
    }
}

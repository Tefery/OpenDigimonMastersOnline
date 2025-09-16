using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GetAdminUsersQueryHandler : IRequestHandler<GetAdminUsersQuery, List<UserDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public GetAdminUsersQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<UserDTO>> Handle(GetAdminUsersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetAdminUsersAsync();
        }
    }
}

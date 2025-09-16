using ODMO.Commons.DTOs.Server;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class ServerByIdQueryHandler : IRequestHandler<ServerByIdQuery, ServerDTO?>
    {
        private readonly IServerQueriesRepository _repository;

        public ServerByIdQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServerDTO?> Handle(ServerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetServerByIdAsync(request.Id);
        }
    }
}

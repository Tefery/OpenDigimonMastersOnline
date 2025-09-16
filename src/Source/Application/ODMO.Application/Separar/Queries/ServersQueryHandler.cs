using ODMO.Commons.DTOs.Server;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class ServersQueryHandler : IRequestHandler<ServersQuery, IList<ServerDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public ServersQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<ServerDTO>> Handle(ServersQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetServersAsync(request.AccessLevel);
        }
    }
}
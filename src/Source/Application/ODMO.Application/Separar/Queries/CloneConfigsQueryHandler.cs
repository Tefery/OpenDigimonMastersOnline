using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class CloneConfigsQueryHandler : IRequestHandler<CloneConfigsQuery, List<CloneConfigDTO>>
    {
        private readonly IServerQueriesRepository _repository;

        public CloneConfigsQueryHandler(IServerQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<CloneConfigDTO>> Handle(CloneConfigsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetCloneConfigsAsync();
        }
    }
}
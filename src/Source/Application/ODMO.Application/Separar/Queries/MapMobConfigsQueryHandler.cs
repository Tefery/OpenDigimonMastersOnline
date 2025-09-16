using ODMO.Commons.DTOs.Config;
using ODMO.Commons.Interfaces;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class MapMobConfigsQueryHandler : IRequestHandler<MapMobConfigsQuery, IList<MobConfigDTO>>
    {
        private readonly IConfigQueriesRepository _repository;

        public MapMobConfigsQueryHandler(IConfigQueriesRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<MobConfigDTO>> Handle(MapMobConfigsQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetMapMobsConfigAsync(request.MapConfigId);
        }
    }
}
using MediatR;
using ODMO.Commons.DTOs.Config;

namespace ODMO.Application.Separar.Queries
{
    public class MapMobConfigsQuery : IRequest<IList<MobConfigDTO>>
    {
        public long MapConfigId { get; private set; }

        public MapMobConfigsQuery(long mapConfigId)
        {
            MapConfigId = mapConfigId;
        }

    }
}
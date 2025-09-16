using ODMO.Commons.DTOs.Events;
using ODMO.Commons.Enums;
using ODMO.Commons.Models.Mechanics;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GetArenaRankingQuery : IRequest<ArenaRankingDTO>
    {
        public ArenaRankingEnum Ranking { get; set; }

        public GetArenaRankingQuery(ArenaRankingEnum arenaRankingEnum)
        {
            Ranking = arenaRankingEnum;
        }
    }
}

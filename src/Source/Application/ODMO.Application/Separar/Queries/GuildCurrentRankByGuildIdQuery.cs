using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GuildCurrentRankByGuildIdQuery : IRequest<short>
    {
        public long GuildId { get; private set; }

        public GuildCurrentRankByGuildIdQuery(long guildId)
        {
            GuildId = guildId;
        }
    }
}
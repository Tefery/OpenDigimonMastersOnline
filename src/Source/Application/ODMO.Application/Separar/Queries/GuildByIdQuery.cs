using ODMO.Commons.DTOs.Mechanics;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GuildByIdQuery : IRequest<GuildDTO?>
    {
        public long GuildId { get; private set; }

        public GuildByIdQuery(long guildId)
        {
            GuildId = guildId;
        }
    }
}
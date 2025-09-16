using ODMO.Commons.DTOs.Mechanics;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GuildByGuildNameQuery : IRequest<GuildDTO?>
    {
        public string GuildName { get; private set; }

        public GuildByGuildNameQuery(string guildName)
        {
            GuildName = guildName;
        }
    }
}
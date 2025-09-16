using ODMO.Commons.DTOs.Mechanics;
using MediatR;

namespace ODMO.Application.Separar.Queries
{
    public class GuildByCharacterIdQuery : IRequest<GuildDTO?>
    {
        public long CharacterId { get; private set; }

        public GuildByCharacterIdQuery(long characterId)
        {
            CharacterId = characterId;
        }
    }
}
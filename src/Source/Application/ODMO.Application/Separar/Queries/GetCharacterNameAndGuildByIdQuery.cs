using MediatR;
using ODMO.Commons.DTOs.Digimon;

namespace ODMO.Application.Separar.Queries
{
    public class GetCharacterNameAndGuildByIdQuery : IRequest<(string TamerName, string GuildName)>
    {
        public long CharacterId { get; }

        public GetCharacterNameAndGuildByIdQuery(long characterId)
        {
            CharacterId = characterId;
        }
    }
}
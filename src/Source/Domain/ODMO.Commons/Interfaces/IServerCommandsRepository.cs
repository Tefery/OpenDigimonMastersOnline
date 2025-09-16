using ODMO.Commons.Models.Mechanics;
using ODMO.Commons.Models.Servers;
using ODMO.Commons.Models.TamerShop;
using ODMO.Commons.DTOs.Mechanics;
using ODMO.Commons.DTOs.Server;
using ODMO.Commons.DTOs.Shop;
using ODMO.Commons.DTOs.Character;
using ODMO.Commons.Enums;
using ODMO.Commons.DTOs.Events;

namespace ODMO.Commons.Interfaces
{
    public interface IServerCommandsRepository
    {
        Task<ServerDTO?> AddServerAsync(ServerObject server);

        Task UpdateServerAsync(long serverId, string serverName, int experience, bool maintenance);

        Task<ConsignedShopDTO?> AddConsignedShopAsync(ConsignedShop personalShop);

        Task<bool> DeleteServerAsync(long id);

        Task DeleteConsignedShopByHandlerAsync(long generalHandler);

        Task<GuildDTO> AddGuildAsync(GuildModel guild);

        Task UpdateGuildNoticeAsync(long guildId, string newMessage);

        Task UpdateGuildAuthorityAsync(GuildAuthorityModel authority);

        Task DeleteGuildAsync(long guildId);

        Task AddGuildHistoricEntryAsync(long guildId, GuildHistoricModel historicEntry);

        Task AddGuildMemberAsync(long guildId, GuildMemberModel member);

        Task UpdateGuildMemberAuthorityAsync(GuildMemberModel guildMember);

        Task DeleteGuildMemberAsync(long characterId, long guildId);
        Task UpdateArenaRankingAsync(ArenaRankingModel arena);
    }
}
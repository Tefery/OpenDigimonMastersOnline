using ODMO.Commons.Enums;
using ODMO.Commons.Enums.ClientEnums;
using ODMO.Commons.DTOs.Account;
using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.DTOs.Chat;
using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Events;
using ODMO.Commons.DTOs.Mechanics;
using ODMO.Commons.DTOs.Server;
using ODMO.Commons.DTOs.Shop;
using ODMO.Commons.Enums.Account;
using ODMO.Commons.Models.Asset;
using ODMO.Commons.Models.Mechanics;

namespace ODMO.Commons.Interfaces
{
    public interface IServerQueriesRepository
    {
        //TODO: separate
        Task<byte> GetCharacterInServerAsync(long accountId, long serverId);

        Task<List<SkillInfoAssetDTO>> GetSkillInfoAssetsAsync();

        Task<List<BuffAssetDTO>> GetBuffInfoAssetsAsync();

        Task<TitleStatusAssetDTO?> GetTitleStatusAssetsAsync(short titleId);

        Task<ItemCraftAssetDTO?> GetItemCraftAssetsByFilterAsync(int npcId, int itemId);

        Task<List<CloneAssetDTO>> GetCloneAssetsAsync();

        Task<List<CloneValueAssetDTO>> GetCloneValueAssetsAsync();

        Task<List<NpcAssetDTO>> GetNpcAssetsAsync();

        Task<IList<ServerDTO>> GetServersAsync(AccountAccessLevelEnum accessLevel);

        Task<List<WelcomeMessageConfigDTO>> GetActiveWelcomeMessagesAssetsAsync();

        Task<List<WelcomeMessageConfigDTO>> GetWelcomeMessagesAssetsAsync();

        Task<IList<AccountDTO>> GetStaffAccountsAsync();

        Task<ServerDTO?> GetServerByIdAsync(long id);

        Task<List<EvolutionAssetDTO>> GetDigimonEvolutionAssetsAsync();

        Task<EvolutionAssetDTO?> GetDigimonEvolutionAssetsByTypeAsync(int type);

        Task<IList<ChatMessageDTO>> GetAllChatMessagesAsync();

        Task<List<SealDetailAssetDTO>> GetSealStatusAssetsAsync();

        Task<List<SkillCodeAssetDTO>> GetSkillCodeAssetsAsync();

        Task<List<DigimonSkillAssetDTO>> GetDigimonSkillAssetsAsync();

        Task<MapRegionListAssetDTO?> GetMapRegionListAssetsAsync(int mapId);

        Task<List<MapConfigDTO>> GetGameMapsConfigAsync(MapTypeEnum mapType);

        Task<List<MapAssetDTO>> GetMapAssetsAsync();

        Task<DigimonBaseInfoAssetDTO?> GetDigimonBaseInfoAsync(int type);
        
        Task<IList<DigimonBaseInfoAssetDTO>> GetAllDigimonBaseInfoAsync();

        Task<DigimonLevelStatusAssetDTO?> GetDigimonLevelingStatusAsync(int type, byte level);

        Task<ConsignedShopDTO?> GetConsignedShopByTamerIdAsync(long characterId);

        Task<ConsignedShopDTO?> GetConsignedShopByHandlerAsync(long generalHandler);

        Task<IList<ConsignedShopDTO>> GetConsignedShopsAsync(int mapId);

        Task<List<ItemAssetDTO>> GetItemAssetsAsync();

        Task<List<CharacterLevelStatusAssetDTO>> GetTamerLevelAssetsAsync();

        Task<List<DigimonLevelStatusAssetDTO>> GetDigimonLevelAssetsAsync();

        Task<XaiAssetDTO?> GetXaiInformationAsync(int itemId);

        Task<AttendanceRewardDTO?> GetTamerAttendanceAsync(long characterId);

        Task<CharacterBaseStatusAssetDTO?> GetTamerBaseStatusAsync(CharacterModelEnum type);

        Task<CharacterLevelStatusAssetDTO?> GetTamerLevelingStatusAsync(CharacterModelEnum type, byte level);
        
        Task<List<ItemAssetDTO>> GetCloneItemAssetsAsync();

        Task<GuildDTO?> GetGuildByCharacterIdAsync(long characterId);

        Task<GuildDTO?> GetGuildByGuildNameAsync(string guildName);

        Task<short> GetGuildRankByGuildIdAsync(long guildId);

        Task<GuildDTO?> GetGuildByIdAsync(long guildId);

        Task<UserAccessLevelEnum> CheckPortalAccessAsync(string username, string password);

        Task<UserAccessLevelEnum> GetAdminAccessLevelAsync(string username);

        Task<List<UserDTO>> GetAdminUsersAsync();

        Task<List<MapConfigDTO>> GetGameMapConfigsForAdminAsync();

        Task<List<ScanDetailAssetDTO>> GetScanDetailAssetsAsync();

        Task<List<StatusApplyAssetDTO>> GetStatusApplyInfoAsync();

        Task<List<TitleStatusAssetDTO>> GetAllTitleStatusInfoAsync();

        Task<List<CharacterBaseStatusAssetDTO>> GetAllTamerBaseStatusAsync();

        Task<List<AccessoryRollAssetDTO>> GetAccessoryRollInfoAsync();

        Task<string> GetResourcesHashAsync();

        Task<List<PortalAssetDTO>> GetPortalAssetsAsync();

        Task<List<ContainerAssetDTO>> GetContainerAssetsAsync();

        Task<List<QuestAssetDTO>> GetQuestAssetsAsync();

        Task<DateTime> GetDailyQuestResetTimeAsync();

        Task<List<HatchAssetDTO>> GetHatchAssetsAsync();

        Task<List<CloneConfigDTO>> GetCloneConfigsAsync();

        Task<List<HatchConfigDTO>> GetHatchConfigsAsync();

        Task<List<FruitConfigDTO>> GetFruitConfigsAsync();
        Task<List<MonsterSkillAssetDTO>> GetMonsterSkillSkillAssetsAsync();
        Task<List<MonsterSkillInfoAssetDTO>> GetMonsterSkillInfoAssetsAsync();
        Task<List<TamerSkillAssetDTO>> GetTamerSkillAssetsAsync();
        Task<List<MonthlyEventAssetDTO>> GetMonthlyEventAssetsAsync();
        Task<List<AchievementAssetDTO>> GetAchievementAssetsAsync();
        Task<List<CashShopAssetDTO>> GetCashShopAssetsAsync();
        Task<List<TimeRewardAssetDTO>> GetTimeRewardAssetsAsync();
        Task<List<TimeRewardDTO>> GetTimeRewardEventsAsync();
        Task<List<SummonDTO>> GetSummonAssetsAsync();
        Task<List<SummonMobDTO>> GetSummonMobAssetsAsync();
        Task<List<NpcColiseumAssetDTO>> GetNpcColiseumAssetsAsync();
        Task<ArenaRankingDTO> GetArenaRankingAsync(ArenaRankingEnum arenaRankingEnum);
        Task<List<ArenaRankingDailyItemRewardsDTO>> GetArenaRankingDailyItemRewardsAsync();
        Task<List<EvolutionArmorAssetDTO>> GetEvolutionArmorAssetsAsync();
        Task<List<ExtraEvolutionNpcAssetDTO>> GetExtraEvolutionNpcAssetAsync();
        Task<List<GotchaAssetDTO>> GetGotchaAssetsAsync();
        Task<List<DeckBuffAssetDTO>> GetDeckBuffAssetsAsync();
    }
}

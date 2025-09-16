using ODMO.Commons.DTOs.Account;
using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.DTOs.Character;
using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;
using ODMO.Commons.DTOs.Server;
using ODMO.Commons.Enums;
using ODMO.Commons.Enums.Account;
using ODMO.Commons.Enums.Character;

namespace ODMO.Commons.Repositories.Admin
{
    public interface IAdminCommandsRepository
    {
        Task<AccountDTO> AddAccountAsync(AccountDTO account);
        Task<SummonDTO> AddSummonConfigAsync(SummonDTO summon);

        Task<CloneConfigDTO> AddCloneConfigAsync(CloneConfigDTO clone);

        Task<ContainerAssetDTO> AddContainerConfigAsync(ContainerAssetDTO container);

        Task<HatchConfigDTO> AddHatchConfigAsync(HatchConfigDTO hatch);

        Task<MobConfigDTO> AddMobAsync(MobConfigDTO mob);
        Task<SummonMobDTO> AddSummonMobAsync(SummonMobDTO mob);


        Task<ScanDetailAssetDTO> AddScanConfigAsync(ScanDetailAssetDTO scan);

        Task<ServerDTO> AddServerAsync(ServerDTO server);

        Task<MapRegionAssetDTO> AddSpawnPointAsync(MapRegionAssetDTO spawnPoint, int mapId);

        Task<UserDTO> AddUserAsync(UserDTO user);
 
        Task<AccountCreateResult> CreateAccountAsync(string username, string email, string discordId, string password);
        
        Task DeleteAccountAsync(long id);
        Task DeleteSummonAsync(long id);

        Task DeleteCloneConfigAsync(long id);

        Task DeleteContainerConfigAsync(long id);

        Task DeleteHatchConfigAsync(long id);

        Task DeleteMapMobsAsync(long id);

        Task DeleteMobAsync(long id);
        Task DeleteSummonMobAsync(long id);


        Task DeleteScanConfigAsync(long id);

        Task DeleteServerAsync(long id);

        Task DeleteSpawnPointAsync(long id);

        Task DeleteUserAsync(long id);

        Task DuplicateMobAsync(long id);
        Task DuplicateSummonMobAsync(long id);


        Task UpdateAccountAsync(AccountDTO account);

        Task<AccountBlockDTO> AddAccountBlockAsync(AccountBlockDTO accountBlock);

        Task UpdateCloneConfigAsync(CloneConfigDTO clone);

        Task UpdateContainerConfigAsync(ContainerAssetDTO container);

        Task UpdateHatchConfigAsync(HatchConfigDTO hatch);

        Task UpdateScanConfigAsync(ScanDetailAssetDTO scan);

        Task UpdateServerAsync(ServerDTO server);

        Task UpdateSpawnPointAsync(MapRegionAssetDTO spawnPoint, long mapId);

        Task UpdateUserAsync(UserDTO user);

        Task<bool> UpdatePlayerAsync(
            long id,
            string name,
            byte level,
            long currentExperience,
            int mapId,
            CharacterStateEnum state,
            CharacterEventStateEnum eventState,
            byte channel,
            CharacterModelEnum model,
            short size,
            int currentHp,
            int currentDs,
            int xGauge,
            short xCrystals,
            short currentTitle,
            byte digimonSlots);
        
        Task<EventConfigDTO> AddEventConfigAsync(EventConfigDTO eventConfig);

        Task UpdateEventConfigAsync(EventConfigDTO eventConfig);

        Task DeleteEventConfigAsync(long id);
        
        Task<EventMapsConfigDTO> AddEventMapConfigAsync(EventMapsConfigDTO eventConfig);

        Task UpdateEventMapConfigAsync(EventMapsConfigDTO eventConfig);

        Task DeleteEventMapConfigAsync(long id);

        Task<EventMobConfigDTO> AddEventMobAsync(EventMobConfigDTO mob);

        Task DeleteEventMapMobsAsync(long id);

        Task DeleteEventMobAsync(long id);
        
        Task DuplicateEventMobAsync(long id);
    }
}
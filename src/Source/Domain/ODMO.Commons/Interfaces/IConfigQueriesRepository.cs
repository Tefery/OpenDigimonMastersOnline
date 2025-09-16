using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;

namespace ODMO.Commons.Interfaces
{
    public interface IConfigQueriesRepository
    {
        Task<IList<MapConfigDTO>> GetGameMapConfigsAsync();

        Task<IList<MobConfigDTO>> GetMapMobsConfigAsync(long configId);

        Task<MapConfigDTO?> GetGameMapConfigByMapIdAsync(int mapId);

        Task<MapConfigDTO?> GetGameMapConfigByIdAsync(long id);

        Task<List<MobConfigDTO>> GetMapMobsByIdAsync(int mapId);

        Task<List<EventConfigDTO>> GetEventsConfigAsync();

        Task<List<EventConfigDTO>> GetEventsConfigAsync(bool isEnabled);
    }
}
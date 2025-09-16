using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Server;
using ODMO.Commons.DTOs.Shop;
using ODMO.Commons.Models.Config;
using ODMO.Commons.Models.Servers;
using ODMO.Commons.Models.TamerShop;

namespace ODMO.Commons.Interfaces
{
    public interface IConfigCommandsRepository
    {
        Task<ServerDTO?> AddServerAsync(ServerObject server);

        Task UpdateServerAsync(long serverId, string serverName, int experience, bool maintenance);

        Task UpdateMapConfigAsync(MapConfigModel mapConfig);

        Task<ConsignedShopDTO?> AddConsignedShopAsync(ConsignedShop personalShop);

        Task<bool> DeleteServerAsync(long id);

        Task DeleteMapConfigAsync(long id);

        Task DeleteMobConfigAsync(long id);

        Task DeleteConsignedShopByHandlerAsync(long generalHandler);

        Task<UserDTO?> AddAdminUserAsync(AdminUserModel user);

        Task UpdateAdminUserAsync(AdminUserModel user);

        Task DeleteAdminUserAsync(long id);

        Task UpdateMobConfigAsync(MobConfigModel mobConfig);
    }
}
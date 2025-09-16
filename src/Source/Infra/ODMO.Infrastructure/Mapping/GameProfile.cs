using AutoMapper;
using ODMO.Commons.DTOs.Base;
using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Mechanics;
using ODMO.Commons.DTOs.Shop;
using ODMO.Commons.Models.Base;
using ODMO.Commons.Models.Map;
using ODMO.Commons.Models.Mechanics;
using ODMO.Commons.Models.TamerShop;

namespace ODMO.Infrastructure.Mapping
{
    public class GameProfile : Profile
    {
        public GameProfile()
        {
            CreateMap<ConsignedShop, ConsignedShopDTO>()
                .ReverseMap();

            CreateMap<GameMap, MapConfigDTO>()
                .ReverseMap();

            CreateMap<GuildModel, GuildDTO>()
                .ReverseMap();

            CreateMap<GuildMemberModel, GuildMemberDTO>()
                .ReverseMap();

            CreateMap<GuildAuthorityModel, GuildAuthorityDTO>()
                .ReverseMap();

            CreateMap<GuildSkillModel, GuildSkillDTO>()
                .ReverseMap();

            CreateMap<GuildHistoricModel, GuildHistoricDTO>()
                .ReverseMap();

            CreateMap<ItemListModel, ItemListDTO>()
                .ReverseMap();

            CreateMap<ItemModel, ItemDTO>()
                .ReverseMap();

            CreateMap<ItemAccessoryStatusModel, ItemAccessoryStatusDTO>()
                .ReverseMap();

            CreateMap<ItemSocketStatusModel, ItemSocketStatusDTO>()
                .ReverseMap();
        }
    }
}
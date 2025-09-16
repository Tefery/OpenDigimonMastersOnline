using AutoMapper;
using ODMO.Commons.Models.Config;
using ODMO.Commons.Models.Servers;
using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Server;
using ODMO.Application.Separar.Queries;
using ODMO.Commons.DTOs.Config.Events;
using ODMO.Commons.Models.Config.Events;
using ODMO.Commons.Models.Summon;

namespace ODMO.Infrastructure.Mapping
{
    public class ConfigProfile : Profile
    {
        public ConfigProfile()
        {
            CreateMap<ServerObject, ServerDTO>()
                .ReverseMap();

            CreateMap<MapConfigModel, MapConfigDTO>()
                .ReverseMap();

            CreateMap<MobConfigModel, MobConfigDTO>()
                .ReverseMap();

            CreateMap<MobLocationConfigModel, MobLocationConfigDTO>()
                .ReverseMap();

            CreateMap<MobExpRewardConfigModel, MobExpRewardConfigDTO>()
                .ReverseMap();

            CreateMap<MobDropRewardConfigModel, MobDropRewardConfigDTO>()
                .ReverseMap();

            CreateMap<BitsDropConfigModel, BitsDropConfigDTO>()
                .ReverseMap();

            CreateMap<ItemDropConfigModel, ItemDropConfigDTO>()
                .ReverseMap();

            CreateMap<SummonModel, SummonDTO>()
                .ReverseMap();

            CreateMap<SummonMobModel, SummonMobDTO>()
                .ReverseMap();

            CreateMap<SummonMobLocationModel, SummonMobLocationDTO>()
                .ReverseMap();

            CreateMap<SummonMobExpRewardModel, SummonMobExpRewardDTO>()
                .ReverseMap();

            CreateMap<SummonMobDropRewardModel, SummonMobDropRewardDTO>()
                .ReverseMap();

            CreateMap<SummonMobBitDropModel, SummonMobBitDropDTO>()
                .ReverseMap();

            CreateMap<SummonMobItemDropModel, SummonMobItemDropDTO>()
                .ReverseMap();

            CreateMap<AdminUserModel, UserDTO>()
                .ReverseMap();

            CreateMap<MapConfigDTO, GetGameMapConfigForAdminQueryDto>()
                .ForMember(
                    dest => dest.Mobs,
                    opt => opt.MapFrom(src => src.Mobs.Count)
                );

            CreateMap<CloneConfigModel, CloneConfigDTO>()
                .ReverseMap();

            CreateMap<HatchConfigModel, HatchConfigDTO>()
                .ReverseMap();

            CreateMap<KillSpawnConfigModel, KillSpawnConfigDTO>()
                .ReverseMap();

            CreateMap<FruitConfigModel, FruitConfigDTO>()
                .ReverseMap();

            CreateMap<FruitSizeConfigModel, FruitSizeConfigDTO>()
                .ReverseMap();

            CreateMap<KillSpawnTargetMobConfigModel, KillSpawnTargetMobConfigDTO>()
                .ReverseMap();

            CreateMap<KillSpawnSourceMobConfigModel, KillSpawnSourceMobConfigDTO>()
                .ReverseMap();

            CreateMap<EventConfigModel, EventConfigDTO>()
                .ReverseMap();

            CreateMap<EventMapsConfigModel, EventMapsConfigDTO>()
                .ReverseMap();

            CreateMap<EventBitsDropConfigModel, EventBitsDropConfigDTO>()
                .ReverseMap();

            CreateMap<EventItemDropConfigModel, EventItemDropConfigDTO>()
                .ReverseMap();

            CreateMap<EventMobConfigModel, EventMobConfigDTO>()
                .ReverseMap();

            CreateMap<EventMobDropRewardConfigModel, EventMobDropRewardConfigDTO>()
                .ReverseMap();

            CreateMap<EventMobExpRewardConfigModel, EventMobExpRewardConfigDTO>()
                .ReverseMap();

            CreateMap<EventMobLocationConfigModel, EventMobLocationConfigDTO>()
                .ReverseMap();
        }
    }
}
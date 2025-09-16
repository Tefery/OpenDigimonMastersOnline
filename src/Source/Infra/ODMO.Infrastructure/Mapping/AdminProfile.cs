using AutoMapper;
using ODMO.Commons.DTOs.Account;
using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.DTOs.Character;
using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;
using ODMO.Commons.DTOs.Server;
using ODMO.Commons.ViewModel.Accounts;
using ODMO.Commons.ViewModel.Clones;
using ODMO.Commons.ViewModel.Containers;
using ODMO.Commons.ViewModel.Events;
using ODMO.Commons.ViewModel.Hatchs;
using ODMO.Commons.ViewModel.Maps;
using ODMO.Commons.ViewModel.Mobs;
using ODMO.Commons.ViewModel.Players;
using ODMO.Commons.ViewModel.Scans;
using ODMO.Commons.ViewModel.Servers;
using ODMO.Commons.ViewModel.SpawnPoint;
using ODMO.Commons.ViewModel.Users;

namespace ODMO.Infrastructure.Mapping
{
    public class AdminProfile : Profile
    {
        public AdminProfile()
        {
            CreateMap<UserDTO, UserViewModel>();

            CreateMap<ServerDTO, ServerViewModel>();

            CreateMap<AccountDTO, AccountViewModel>();

            CreateMap<MapConfigDTO, MapViewModel>()
                .ForMember(dest => dest.MobsCount, x => x.MapFrom(src => src.Mobs.Count));

            CreateMap<MobConfigDTO, MobViewModel>()
                .ReverseMap();

            CreateMap<MobLocationConfigDTO, MobLocationViewModel>()
                .ReverseMap();

            CreateMap<MobExpRewardConfigDTO, MobExpRewardViewModel>()
                .ReverseMap();

            CreateMap<MobDropRewardConfigDTO, MobDropRewardViewModel>()
                .ReverseMap();

            CreateMap<ItemDropConfigDTO, MobItemDropViewModel>()
                .ReverseMap();

            CreateMap<BitsDropConfigDTO, MobBitDropViewModel>()
                .ReverseMap();

            CreateMap<EventMapsConfigDTO, EventMapViewModel>()
                .ForMember(dest => dest.MobsCount, x => x.MapFrom(src => src.Mobs.Count));

            CreateMap<EventMobConfigDTO, MobViewModel>()
                .ReverseMap();

            CreateMap<EventMobLocationConfigDTO, MobLocationViewModel>()
                .ReverseMap();

            CreateMap<EventMobExpRewardConfigDTO, MobExpRewardViewModel>()
                .ReverseMap();

            CreateMap<EventMobDropRewardConfigDTO, MobDropRewardViewModel>()
                .ReverseMap();

            CreateMap<EventItemDropConfigDTO, MobItemDropViewModel>()
                .ReverseMap();

            CreateMap<EventBitsDropConfigDTO, MobBitDropViewModel>()
                .ReverseMap();

            CreateMap<MapRegionAssetDTO, SpawnPointViewModel>()
                .ReverseMap();

            CreateMap<MapRegionAssetDTO, SpawnPointCreationViewModel>()
                .ReverseMap();

            CreateMap<MapRegionAssetDTO, SpawnPointUpdateViewModel>()
                .ReverseMap();

            CreateMap<ScanDetailAssetDTO, ScanDetailViewModel>()
                .ReverseMap();

            CreateMap<ScanRewardDetailAssetDTO, ScanRewardDetailViewModel>()
                .ReverseMap();

            CreateMap<ContainerAssetDTO, ContainerViewModel>()
                .ReverseMap();

            CreateMap<ContainerRewardAssetDTO, ContainerRewardViewModel>()
                .ReverseMap();

            CreateMap<CloneConfigDTO, CloneViewModel>()
                .ReverseMap();

            CreateMap<HatchConfigDTO, HatchViewModel>()
                .ReverseMap();

            CreateMap<CharacterDTO, PlayerViewModel>()
                .ForMember(x => x.MapId, src => src.MapFrom(y => y.Location.MapId))
                .ReverseMap();
        }
    }
}
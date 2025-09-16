using AutoMapper;
using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.DTOs.Character;
using ODMO.Commons.DTOs.Events;
using ODMO.Commons.Model.Character;
using ODMO.Commons.Models.Character;
using ODMO.Commons.Models.Events;
using ODMO.Commons.Models.Mechanics;

namespace ODMO.Infrastructure.Mapping
{
    public class CharacterProfile : Profile
    {
        public CharacterProfile()
        {
            CreateMap<CharacterModel, CharacterDTO>()
                .ForMember(x => x.Guild, y => y.Ignore())
                .ReverseMap();

            CreateMap<CharacterLocationModel, CharacterLocationDTO>()
                .ReverseMap();

            CreateMap<CharacterIncubatorModel, CharacterIncubatorDTO>()
                .ReverseMap();

            CreateMap<CharacterMapRegionModel, CharacterMapRegionDTO>()
                .ReverseMap();

            CreateMap<CharacterBuffListModel, CharacterBuffListDTO>()
                .ReverseMap();

            CreateMap<CharacterBuffModel, CharacterBuffDTO>()
                .ReverseMap();

            CreateMap<CharacterSealListModel, CharacterSealListDTO>()
                .ReverseMap();

            CreateMap<CharacterSealModel, CharacterSealDTO>()
                .ReverseMap();

            CreateMap<CharacterXaiModel, CharacterXaiDTO>()
                .ReverseMap();

            CreateMap<XaiAssetDTO, CharacterXaiModel>()
                .ForMember(dest => dest.Id, x => x.Ignore());

            CreateMap<TimeRewardDTO, TimeRewardModel>()
                .ForMember(dest => dest.Id, x => x.Ignore())
                .ReverseMap();

            CreateMap<AttendanceRewardDTO, AttendanceRewardModel>()
                .ForMember(dest => dest.Id, x => x.Ignore())
                .ReverseMap();

            CreateMap<CharacterFriendModel, CharacterFriendDTO>()
                .ReverseMap();

            CreateMap<CharacterFoeModel, CharacterFoeDTO>()
                .ReverseMap();

            CreateMap<CharacterProgressModel, CharacterProgressDTO>()
                .ReverseMap();

            CreateMap<InProgressQuestModel, InProgressQuestDTO>()
                .ReverseMap();

            CreateMap<CharacterActiveEvolutionModel, CharacterActiveEvolutionDTO>()
                .ReverseMap();

            CreateMap<CharacterDigimonArchiveModel, CharacterDigimonArchiveDTO>()
                .ReverseMap();

            CreateMap<CharacterDigimonArchiveItemModel, CharacterDigimonArchiveItemDTO>()
                .ReverseMap();

            CreateMap<CharacterArenaPointsModel, CharacterArenaPointsDTO>()
                .ReverseMap();

            CreateMap<CharacterArenaDailyPointsModel, CharacterArenaDailyPointsDTO>()
                .ForMember(dest => dest.Id, x => x.Ignore())
                .ReverseMap();

            CreateMap<CharacterTamerSkillModel, CharacterTamerSkillDTO>()
                .ForMember(dest => dest.Id, x => x.Ignore())
                .ReverseMap();

            CreateMap<CharacterEncyclopediaModel, CharacterEncyclopediaDTO>()
                .ReverseMap();

            CreateMap<CharacterEncyclopediaEvolutionsModel, CharacterEncyclopediaEvolutionsDTO>()
                .ReverseMap();

            CreateMap<CharacterEncyclopediaEvolutionsDTO, CharacterEncyclopediaEvolutionsModel>()
                .ReverseMap();
        }
    }
}
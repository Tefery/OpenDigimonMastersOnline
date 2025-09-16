using AutoMapper;
using ODMO.Commons.DTOs.Events;
using ODMO.Commons.Models.Mechanics;


namespace ODMO.Infrastructure.Mapping
{
    public class ArenaProfile : Profile
    {
        public ArenaProfile()
        {
            CreateMap<ArenaRankingModel, ArenaRankingDTO>()
                .ReverseMap();


            CreateMap<ArenaRankingCompetitorModel, ArenaRankingCompetitorDTO>()
                .ReverseMap();
        }
    }
}
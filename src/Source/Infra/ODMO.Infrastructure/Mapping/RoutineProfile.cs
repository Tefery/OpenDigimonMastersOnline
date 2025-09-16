using AutoMapper;
using ODMO.Commons.DTOs.Routine;
using ODMO.Commons.DTOs.Routine;

namespace ODMO.Infrastructure.Mapping
{
    public class RoutineProfile : Profile
    {
        public RoutineProfile()
        {
            CreateMap<RoutineDTO, RoutineModel>();
        }
    }
}
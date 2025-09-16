using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;

namespace ODMO.Application.Admin.Queries
{
    public class GetEventMapMobsQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<EventMobConfigDTO> Registers { get; set; }
    }
}
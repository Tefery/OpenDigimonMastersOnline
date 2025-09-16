using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;

namespace ODMO.Application.Admin.Queries
{
    public class GetEventsQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<EventConfigDTO> Registers { get; set; }
    }
}
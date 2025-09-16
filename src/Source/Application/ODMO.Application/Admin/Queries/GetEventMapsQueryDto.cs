using ODMO.Commons.DTOs.Config;
using ODMO.Commons.DTOs.Config.Events;

namespace ODMO.Application.Admin.Queries
{
    public class GetEventMapsQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<EventMapsConfigDTO> Registers { get; set; }
    }
}
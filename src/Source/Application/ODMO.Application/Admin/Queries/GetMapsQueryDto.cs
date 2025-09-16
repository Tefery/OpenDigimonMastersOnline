using ODMO.Commons.DTOs.Config;

namespace ODMO.Application.Admin.Queries
{
    public class GetMapsQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<MapConfigDTO> Registers { get; set; }
    }
}
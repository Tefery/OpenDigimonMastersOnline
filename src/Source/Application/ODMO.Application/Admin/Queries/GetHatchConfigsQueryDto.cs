using ODMO.Commons.DTOs.Config;

namespace ODMO.Application.Admin.Queries
{
    public class GetHatchConfigsQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<HatchConfigDTO> Registers { get; set; }
    }
}
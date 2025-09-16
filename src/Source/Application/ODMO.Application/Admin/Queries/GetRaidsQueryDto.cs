using ODMO.Commons.DTOs.Config;

namespace ODMO.Application.Admin.Queries
{
    public class GetRaidsQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<MobConfigDTO> Registers { get; set; }
    }
}
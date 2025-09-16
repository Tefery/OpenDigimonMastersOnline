using ODMO.Commons.DTOs.Config;

namespace ODMO.Application.Admin.Queries
{
    public class GetClonsQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<CloneConfigDTO> Registers { get; set; }
    }
}
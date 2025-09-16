using ODMO.Commons.DTOs.Config;

namespace ODMO.Application.Admin.Queries
{
    public class GetSummonsQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<SummonDTO> Registers { get; set; }
    }
}
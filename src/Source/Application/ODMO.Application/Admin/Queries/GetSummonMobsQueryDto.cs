using ODMO.Commons.DTOs.Config;

namespace ODMO.Application.Admin.Queries
{
    public class GetSummonMobsQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<SummonMobDTO> Registers { get; set; }
    }
}
using ODMO.Commons.DTOs.Server;

namespace ODMO.Application.Admin.Queries
{
    public class GetServersQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<ServerDTO> Registers { get; set; }
    }
}
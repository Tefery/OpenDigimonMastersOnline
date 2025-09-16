using ODMO.Commons.DTOs.Config;

namespace ODMO.Application.Admin.Queries
{
    public class GetUsersQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<UserDTO> Registers { get; set; }
    }
}
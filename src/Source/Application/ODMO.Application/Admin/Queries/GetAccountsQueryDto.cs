using ODMO.Commons.DTOs.Account;

namespace ODMO.Application.Admin.Queries
{
    public class GetAccountsQueryDto
    {
        public int TotalRegisters { get; set; }
        public List<AccountDTO> Registers { get; set; }
    }
}
using ODMO.Commons.DTOs.Account;
using Microsoft.EntityFrameworkCore;
using ODMO.Infrastructure.ContextConfiguration.Config;
using ODMO.Infrastructure.ContextConfiguration.Account;

namespace ODMO.Infrastructure
{
    public partial class DatabaseContext
    {
        public DbSet<AccountDTO> Account { get; set; }
        public DbSet<AccountBlockDTO> AccountBlock { get; set; }
        public DbSet<SystemInformationDTO> SystemInformation { get; set; }

        internal static void AccountEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AccountConfiguration());
            builder.ApplyConfiguration(new SystemInformationConfiguration());
            builder.ApplyConfiguration(new AccountBlockConfiguration());
        }
    }
}
using ODMO.Commons.DTOs.Account;
using ODMO.Commons.DTOs.Chat;
using ODMO.Infrastructure.ContextConfiguration.Security;
using Microsoft.EntityFrameworkCore;

namespace ODMO.Infrastructure
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<LoginTryDTO> LoginTry { get; set; }
        public DbSet<ChatMessageDTO> ChatMessage { get; set; }

        internal static void SecurityEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new LoginTryConfiguration());
            builder.ApplyConfiguration(new ChatMessageConfiguration());
        }
    }
}
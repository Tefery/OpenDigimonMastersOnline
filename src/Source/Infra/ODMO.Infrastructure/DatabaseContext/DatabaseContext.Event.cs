using ODMO.Commons.DTOs.Events;
using ODMO.Infrastructure.ContextConfiguration.Event;
using Microsoft.EntityFrameworkCore;

namespace ODMO.Infrastructure
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<TimeRewardDTO> TimeReward { get; set; }
        public DbSet<AttendanceRewardDTO> AttendanceReward { get; set; }

        internal static void EventEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new TimeRewardConfiguration());
            builder.ApplyConfiguration(new AttendanceRewardConfiguration());
        }
    }
}
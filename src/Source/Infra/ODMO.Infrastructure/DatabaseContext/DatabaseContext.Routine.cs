using Microsoft.EntityFrameworkCore;
using ODMO.Commons.DTOs.Routine;
using ODMO.Infrastructure.ContextConfiguration.Routine;

namespace ODMO.Infrastructure
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<RoutineDTO> Routine { get; set; }

        internal static void RoutineEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new RoutineConfiguration());
        }
    }
}
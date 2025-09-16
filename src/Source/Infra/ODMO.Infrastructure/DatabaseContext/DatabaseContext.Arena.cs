using ODMO.Commons.DTOs.Mechanics;
using Microsoft.EntityFrameworkCore;
using ODMO.Commons.DTOs.Events;
using ODMO.Infrastructure.ContextConfiguration.Mechanics;
using ODMO.Infrastructure.ContextConfiguration.Arena;


namespace ODMO.Infrastructure
{
    public partial class DatabaseContext : DbContext
    {
        public DbSet<ArenaRankingDTO> ArenaRanking { get; set; }
        public DbSet<ArenaRankingCompetitorDTO> Competitor { get; set; }
     
        internal static void ArenaEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ArenaRankingConfiguration());
            builder.ApplyConfiguration(new ArenaRankingCompetitorConfiguration());
        }
    }
}

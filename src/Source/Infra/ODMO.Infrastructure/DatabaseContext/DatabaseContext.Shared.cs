using Microsoft.EntityFrameworkCore;
using ODMO.Commons.DTOs.Base;
using ODMO.Infrastructure.ContextConfiguration.Shared;

namespace ODMO.Infrastructure
{
    public partial class DatabaseContext
    {
        public DbSet<ItemListDTO> ItemLists { get; set; }
        public DbSet<ItemDTO> Items { get; set; }
        public DbSet<ItemAccessoryStatusDTO> ItemAccsStatus { get; set; }
        public DbSet<ItemSocketStatusDTO> ItemSocketStatus { get; set; }

        internal static void SharedEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ItemAccessoryStatusConfiguration());
            builder.ApplyConfiguration(new ItemSocketStatusConfiguration());
            builder.ApplyConfiguration(new ItemListConfiguration());
            builder.ApplyConfiguration(new ItemConfiguration());
        }
    }
}
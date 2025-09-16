using ODMO.Infrastructure.ContextConfiguration.Shop;
using Microsoft.EntityFrameworkCore;

namespace ODMO.Infrastructure
{
    public partial class DatabaseContext : DbContext
    {
        //TODO: Tamershop, Cashshop
        internal static void ShopEntityConfiguration(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ConsignedShopConfiguration());
            builder.ApplyConfiguration(new ConsignedShopLocationConfiguration());
        }
    }
}
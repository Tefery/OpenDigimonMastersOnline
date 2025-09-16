using ODMO.Commons.DTOs.Assets;
using ODMO.Commons.Models.Asset;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ODMO.Infrastructure.ContextConfiguration.Assets
{
    public class CashShopAssetConfiguration : IEntityTypeConfiguration<CashShopAssetDTO>
    {
        public void Configure(EntityTypeBuilder<CashShopAssetDTO> builder)
        {

            builder
                .ToTable("CashShop", "Asset")
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Item_Id)
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();

            builder
                .Property(x => x.Id)
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();

            builder
                .Property(x => x.Unique_Id)
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();

            builder
                .Property(x => x.Quanty)
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();

            builder
                .Property(x => x.Price)
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();

            builder
                .Property(x => x.Activated)
                .HasColumnType("int")
                .HasDefaultValue(0)
                .IsRequired();

            builder
                .Property(x => x.ItemName)
                .HasColumnType("varchar")
                .HasMaxLength(30)
                .IsRequired();
        }
    }
}
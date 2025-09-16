using ODMO.Commons.DTOs.Character;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ODMO.Infrastructure.ContextConfiguration.Character
{
    public class CharacterArenaPointsConfiguration : IEntityTypeConfiguration<CharacterArenaPointsDTO>
    {
        public void Configure(EntityTypeBuilder<CharacterArenaPointsDTO> builder)
        {
            builder
                .ToTable("ArenaPoints", "Character")
                .HasKey(x => x.Id);
            
            builder
                .Property(x => x.ItemId)
                .HasColumnType("int")
                .IsRequired();

            builder
                .Property(x => x.Amount)
                .HasColumnType("int")
                .IsRequired();

            builder
               .Property(x => x.CurrentStage)
               .HasColumnType("int")
               .IsRequired();
         
        }
    }
}
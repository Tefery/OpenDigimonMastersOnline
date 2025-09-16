
using ODMO.Commons.DTOs.Character;
using ODMO.Commons.DTOs.Events;
using ODMO.Commons.Enums.Character;
using ODMO.Commons.Enums.ClientEnums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ODMO.Infrastructure.ContextConfiguration.Character
{
    public class CharacterTamerSkillConfiguration : IEntityTypeConfiguration<CharacterTamerSkillDTO>
    {
        public void Configure(EntityTypeBuilder<CharacterTamerSkillDTO> builder)
        {
            builder
                .ToTable("ActiveSkill", "Character")
                .HasKey(x => x.Id);

            builder
              .Property(x => x.Type)
              .HasColumnType("int")
              .HasConversion(new ValueConverter<TamerSkillTypeEnum, int>(
                  x => (int)x,
                  x => (TamerSkillTypeEnum)x))
              .HasDefaultValue(TamerSkillTypeEnum.Normal)
              .IsRequired();

                builder
              .Property(x => x.Duration)
              .HasColumnType("int")
              .HasDefaultValueSql("0")
              .IsRequired();
             
                builder
                 .Property(x => x.EndDate)
                 .HasColumnType("datetime2")
                 .HasDefaultValueSql("getdate()")
                 .IsRequired();

            builder
            .Property(x => x.Cooldown)
            .HasColumnType("int")
            .HasDefaultValueSql("0")
            .IsRequired();

            builder
             .Property(x => x.EndCooldown)
             .HasColumnType("datetime2")
             .HasDefaultValueSql("getdate()")
             .IsRequired();

        }
    }
}
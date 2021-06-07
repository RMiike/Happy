using H.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace H.Data.Mapping
{
    public class OrphanageMapping : IEntityTypeConfiguration<Orphanage>
    {
        public void Configure(EntityTypeBuilder<Orphanage> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Orphanage");

            builder.Property(x => x.Name)
                .HasColumnType("varchar(20)")
                .IsRequired(true);

            builder.Property(x => x.Latitude)
               .HasColumnType("decimal(10,8)")
               .IsRequired(true);


            builder.Property(x => x.Longitude)
               .HasColumnType("decimal(10,8)")
               .IsRequired(true);

            builder.Property(x => x.About)
              .HasColumnType("varchar(150)")
              .IsRequired(true);

            builder.Property(x => x.Instructions)
              .HasColumnType("varchar(150)")
              .IsRequired(true);

            builder.Property(x => x.OpeningHours)
              .HasColumnType("varchar(20)")
              .IsRequired(true);

            builder.Property(x => x.OpenOnWeekends)
              .HasColumnType("bit")
              .IsRequired(true);


            builder.Property(x => x.Pending)
              .HasColumnType("bit")
              .IsRequired();

            builder.Ignore(x => x.ErrorMessages);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}

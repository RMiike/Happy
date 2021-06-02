using H.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace H.Data.Mapping
{
    public class ImageMapping : IEntityTypeConfiguration<Image>
    {
        public void Configure(EntityTypeBuilder<Image> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("Image");

            builder.Property(x => x.Path)
                .HasColumnType("varchar(250)")
                .IsRequired(true);

            builder.HasOne(x => x.Orphanage)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.OrphanageId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(x => x.ErrorMessages);
            builder.Ignore(x => x.ValidationResult);
        }
    }
}

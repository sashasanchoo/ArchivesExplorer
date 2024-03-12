using ArchivesExplorer.DataContext.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArchivesExplorer.DataContext.Configuration
{
    public class ImagePathConfiguration : IEntityTypeConfiguration<ImagePath>
    {
        public void Configure(EntityTypeBuilder<ImagePath> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Path).IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.Images)
                .HasForeignKey(x => x.ProductId);
        }
    }
}

using Ecom.core.Entities.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecom.Infrustructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(x => x.Description)
                .HasMaxLength(1000);

            builder.Property(x => x.NewPrice)
                .HasColumnType("decimal(18,2)");

            builder.Property(x => x.OldPrice)
                .HasColumnType("decimal(18,2)");

            builder.HasData(new Product
            {
                Id = 1,
                Name = "Product 1",
                Description = "Description for Product 1",
                NewPrice = 10.99m,
                OldPrice = 0m,
                CategoryId = 1
            });

        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PcStore.Data.Models;

namespace PcStore.Data.Configuration
{
    internal class ProductLaptopConfiguration : IEntityTypeConfiguration<ProductLaptop>
    {
        public void Configure(EntityTypeBuilder<ProductLaptop> builder)
        {
            builder
                .HasKey(pc => new { pc.ProductId, pc.LaptopId });

            builder
               .Property(cm => cm.IsDeleted)
               .HasDefaultValue(false);

            builder
              .HasOne(l => l.Product)
              .WithMany(p => p.ProductsLaptops)
              .HasForeignKey(l => l.ProductId)
              .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Laptop)
                .WithMany(l => l.LaptopsProducts)
                .HasForeignKey(p => p.LaptopId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

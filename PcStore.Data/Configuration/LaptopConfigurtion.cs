
namespace PcStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PcStore.Data.Models;
    using static Common.EntityValidationConstants.Laptop;
    public class LaptopConfigurtion : IEntityTypeConfiguration<Laptop>
    {
        public void Configure(EntityTypeBuilder<Laptop> builder)
        {
            builder.HasKey(m => m.Id);

            builder
               .Property(m => m.Brand)
               .IsRequired(true)
               .HasMaxLength(BrandMaxLength);

            builder
                .Property(m => m.Description)
                .IsRequired(true)
                .HasMaxLength(DescriptionMaxLength);

            builder
                .Property(m => m.Price)
                .IsRequired(true)
                .HasMaxLength(PriceMaxValue);

            builder
                .Property(m => m.ImageUrl)
                .IsRequired(false);

            builder.HasData(this.GenerateLaptops());
        }
        private IEnumerable<Laptop> GenerateLaptops()
        {
            IEnumerable<Laptop> laptops = new List<Laptop>()
            {
                new Laptop()
                {
                    Brand = "HP",
                    Description = "Nice Laptop",
                    Price = 1200

                },
                new Laptop()
                {
                    Brand = "Dell",
                    Description = "Buy now",
                    Price = 1800
                },
                new Laptop()
                {
                    Brand = "Lenovo",
                    Description = "Best Laptop",
                    Price = 3000
                }
            };

            return laptops;
        }
    }
}

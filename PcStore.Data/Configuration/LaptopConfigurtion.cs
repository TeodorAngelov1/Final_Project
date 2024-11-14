
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
                .Property(m => m.LaptopName)
                .IsRequired(true)
                .HasMaxLength(NameMaxLength);

            builder
                .Property(m => m.LaptopDescription)
                .IsRequired(true)
                .HasMaxLength(DescriptionMaxLength);

            builder
                .Property(m => m.LaptopPrice)
                .IsRequired(true)
                .HasMaxLength(PriceMaxValue);

            builder
                .Property(m => m.LaptopImageUrl)
                .IsRequired(false);

            builder.HasData(this.GenerateLaptops());
        }
        private IEnumerable<Laptop> GenerateLaptops()
        {
            IEnumerable<Laptop> laptops = new List<Laptop>()
            {
                new Laptop()
                {
                    LaptopName = "HP",
                    LaptopDescription = "Nice Laptop",
                    LaptopPrice = 1200

                },
                new Laptop()
                {
                    LaptopName = "Dell",
                    LaptopDescription = "Buy now",
                    LaptopPrice = 1800
                },
                new Laptop()
                {
                    LaptopName = "Lenovo",
                    LaptopDescription = "Best Laptop",
                    LaptopPrice = 3000
                }
            };

            return laptops;
        }
    }
}

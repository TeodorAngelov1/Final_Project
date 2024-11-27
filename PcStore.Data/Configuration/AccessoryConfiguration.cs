using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PcStore.Data.Models;
using static PcStore.Common.EntityValidationConstants.Accessory;
namespace PcStore.Data.Configuration
{
    public class AccessoryConfiguration : IEntityTypeConfiguration<Accessory>
    {
        public void Configure(EntityTypeBuilder<Accessory> builder)
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
        private IEnumerable<Accessory> GenerateLaptops()
        {
            IEnumerable<Accessory> accessories = new List<Accessory>()
            {
                new Accessory()
                {
                    Brand = "Sony Headphones",
                    Description = "The Best",
                    Price = 400

                },
                new Accessory()
                {
                    Brand = "JBL T100",
                    Description = "Buy now",
                    Price = 300
                },
                new Accessory()
                {
                    Brand = "BOSE Wireless Headphones",
                    Description = "Nice sound",
                    Price = 250
                }
            };

            return accessories;
        }
    }
}

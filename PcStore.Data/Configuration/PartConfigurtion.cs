using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PcStore.Data.Models;
using static PcStore.Common.EntityValidationConstants.Part;

namespace PcStore.Data.Configuration
{
    public class PartConfigurtion : IEntityTypeConfiguration<Part>
    {
        public void Configure(EntityTypeBuilder<Part> builder)
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

            builder.HasData(this.GenerateParts());
        }
        private IEnumerable<Part> GenerateParts()
        {
            IEnumerable<Part> parts = new List<Part>()
            {
                new Part()
                {
                    Brand = "Samsung",
                    Description = "RAM Memory",
                    Price = 200

                },
                new Part()
                {
                    Brand = "Kingston",
                    Description = "SSD",
                    Price = 800
                },
                new Part()
                {
                    Brand= "Seagete",
                    Description = "HDD",
                    Price = 100
                }
            };

            return parts;
        }
    }
}

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
                .Property(m => m.PartBrand)
                .IsRequired(true)
                .HasMaxLength(NameMaxLength);

            builder
                .Property(m => m.PartDescription)
                .IsRequired(true)
                .HasMaxLength(DescriptionMaxLength);

            builder
                .Property(m => m.PartPrice)
                .IsRequired(true)
                .HasMaxLength(PriceMaxValue);

            builder
                .Property(m => m.PartImageUrl)
                .IsRequired(false);

            builder.HasData(this.GenerateParts());
        }
        private IEnumerable<Part> GenerateParts()
        {
            IEnumerable<Part> parts = new List<Part>()
            {
                new Part()
                {
                    PartBrand = "Samsung",
                    PartDescription = "RAM Memory",
                    PartPrice = 200

                },
                new Part()
                {
                    PartBrand = "Kingston",
                    PartDescription = "SSD",
                    PartPrice = 800
                },
                new Part()
                {
                    PartBrand= "Seagete",
                    PartDescription = "HDD",
                    PartPrice = 100
                }
            };

            return parts;
        }
    }
}

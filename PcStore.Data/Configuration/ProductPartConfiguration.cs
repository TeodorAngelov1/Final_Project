using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PcStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcStore.Data.Configuration
{
    internal class ProductPartConfiguration : IEntityTypeConfiguration<ProductPart>
    {
        public void Configure(EntityTypeBuilder<ProductPart> builder)
        {
            builder
                .HasKey(pc => new { pc.ProductId, pc.PartId });

            builder
               .Property(cm => cm.IsDeleted)
               .HasDefaultValue(false);

            builder
              .HasOne(pr => pr.Product)
              .WithMany(p => p.ProductsParts)
              .HasForeignKey(pr => pr.ProductId)
              .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(pa => pa.Part)
                .WithMany(pr => pr.PartsProducts)
                .HasForeignKey(pa => pa.PartId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

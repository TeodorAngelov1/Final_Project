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
    public class ProductClientConfiguration : IEntityTypeConfiguration<ProductClient>
    {
        public void Configure(EntityTypeBuilder<ProductClient> builder)
        {
            builder
                .HasKey(pc => new { pc.ProductId, pc.ClientId });

            builder
               .Property(cm => cm.IsDeleted)
               .HasDefaultValue(false);

            builder
              .HasOne(c => c.Product)
              .WithMany(p => p.ProductsClients)
              .HasForeignKey(c => c.ProductId)
              .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Client)
                .WithMany(c => c.ProductsClients)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

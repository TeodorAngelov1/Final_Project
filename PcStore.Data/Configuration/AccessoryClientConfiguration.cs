using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PcStore.Data.Models;

namespace PcStore.Data.Configuration
{
    public class AccessoryClientConfiguration : IEntityTypeConfiguration<AccessoryClient>
    {
        public void Configure(EntityTypeBuilder<AccessoryClient> builder)
        {
            builder
                  .HasKey(pc => new { pc.AccessoryId, pc.ClientId });



            builder
              .HasOne(c => c.Accessory)
              .WithMany(p => p.AccessoriesClients)
              .HasForeignKey(c => c.AccessoryId)
              .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Client)
                .WithMany(c => c.ClientsAccessories)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

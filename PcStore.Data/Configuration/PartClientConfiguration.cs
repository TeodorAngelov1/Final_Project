using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PcStore.Data.Models;

namespace PcStore.Data.Configuration
{
    public class PartClientConfiguration : IEntityTypeConfiguration<PartClient>
    {
            public void Configure(EntityTypeBuilder<PartClient> builder)
            {
                builder
                    .HasKey(pc => new { pc.PartId, pc.ClientId });


                builder
                  .HasOne(c => c.Part)
                  .WithMany(p => p.PartsClients)
                  .HasForeignKey(c => c.PartId)
                  .OnDelete(DeleteBehavior.Restrict);

                builder
                    .HasOne(p => p.Client)
                    .WithMany(c => c.ClientsParts)
                    .HasForeignKey(p => p.ClientId)
                    .OnDelete(DeleteBehavior.Restrict);
            }
        
    }
}

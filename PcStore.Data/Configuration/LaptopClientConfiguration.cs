﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PcStore.Data.Models;
namespace PcStore.Data.Configuration
{
    public class LaptopClientConfiguration : IEntityTypeConfiguration<LaptopClient>
    {
        public void Configure(EntityTypeBuilder<LaptopClient> builder)
        {
            builder
                   .HasKey(pc => new { pc.LaptopId, pc.ClientId });

           

            builder
              .HasOne(c => c.Laptop)
              .WithMany(p => p.LaptopsClients)
              .HasForeignKey(c => c.LaptopId)
              .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(p => p.Client)
                .WithMany(c => c.ClientsLaptops)
                .HasForeignKey(p => p.ClientId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

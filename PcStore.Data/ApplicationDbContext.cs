using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PcStore.Data.Models;
using System.Reflection;

namespace PcStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public virtual DbSet<PartClient> PartsClients { get; set; } = null!;

        public virtual DbSet<LaptopClient> LaptopsClients { get; set; } = null!;

        public virtual DbSet<AccessoryClient> AccessoriesClients { get; set; } = null!;

        public virtual DbSet<Part> Parts { get; set; } = null!;

        public virtual DbSet<Laptop> Laptops { get; set; } = null!;

        public virtual DbSet<Accessory> Accessories { get; set; } = null!;



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

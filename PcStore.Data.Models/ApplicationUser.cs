namespace PcStore.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid();
        }

        public virtual ICollection<LaptopClient> ClientsLaptops { get; set; }
            = new HashSet<LaptopClient>();

        public virtual ICollection<PartClient> ClientsParts { get; set; }
           = new HashSet<PartClient>();

        public virtual ICollection<AccessoryClient> ClientsAccessories { get; set; }
           = new HashSet<AccessoryClient>();
    }
}

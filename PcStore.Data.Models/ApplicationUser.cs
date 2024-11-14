namespace PcStore.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser<Guid>
    {
        public ApplicationUser()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            this.Id = Guid.NewGuid();
        }

        public virtual ICollection<ProductClient> ProductsClients { get; set; }
            = new HashSet<ProductClient>();

      
    }
}

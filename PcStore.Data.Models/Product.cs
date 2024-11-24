using Microsoft.AspNetCore.Identity;

namespace PcStore.Data.Models
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string ProductName { get; set; } = null!;

        public Guid SellerId { get; set; } 

        public ApplicationUser Seller { get; set; } = null!;

        public Guid CategoryId { get; set; }

        public Category Category { get; set; } = null!;

        public bool IsDeleted { get; set; }

        public IEnumerable<ProductClient> ProductsClients { get; set; } = new List<ProductClient>();

        public IEnumerable<ProductLaptop> ProductsLaptops { get; set; } = new List<ProductLaptop>();

        public IEnumerable<ProductPart> ProductsParts { get; set; } = new List<ProductPart>();
    }
}

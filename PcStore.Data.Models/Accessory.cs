namespace PcStore.Data.Models
{
    public class Accessory : IProduct
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Brand { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public List<AccessoryClient> AccessoriesClients { get; set; } = new List<AccessoryClient>();
    }
}

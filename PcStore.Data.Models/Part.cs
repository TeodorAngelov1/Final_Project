

namespace PcStore.Data.Models
{
    public class Part
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Brand { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; }
        public IEnumerable<PartClient> PartsClients { get; set; } = new List<PartClient>();
    }
}

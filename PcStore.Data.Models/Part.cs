

namespace PcStore.Data.Models
{
    public class Part
    {
        public Guid Id { get; set; } = Guid.NewGuid();


        public string PartBrand { get; set; } = null!;

        public string PartDescription { get; set; } = null!;

        public decimal PartPrice { get; set; }

        public string? PartImageUrl { get; set; }

        public bool IsDeleted { get; set; }
        public IEnumerable<ProductPart> PartsProducts { get; set; } = new List<ProductPart>();
    }
}

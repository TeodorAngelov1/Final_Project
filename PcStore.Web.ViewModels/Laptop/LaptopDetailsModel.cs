namespace PcStore.Web.ViewModels.Laptop
{
    public class LaptopDetailsModel 
    {
        public string Id { get; set; } = null!;
        public string Brand { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }
        
    }
}

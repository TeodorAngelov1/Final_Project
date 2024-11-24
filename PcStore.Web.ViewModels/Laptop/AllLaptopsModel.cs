


namespace PcStore.Web.ViewModels.Laptop
{
   

    using Data.Models;
    public class AllLaptopsModel 
    {
        public string Id { get; set; } = null!;

        public string LaptopName { get; set; } = null!;

        public string LaptopDescription { get; set; } = null!;

        public decimal LaptopPrice { get; set; }

        public string? LaptopImageUrl { get; set; }

        
    }
}

namespace PcStore.Data.Models
{
    public class LaptopClient
    {
        public Guid LaptopId { get; set; } 
        public Laptop Laptop { get; set; } = null!;

        public Guid ClientId { get; set; } 

        public ApplicationUser Client { get; set; } = null!;


    }
}

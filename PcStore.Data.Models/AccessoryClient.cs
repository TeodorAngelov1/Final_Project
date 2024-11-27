namespace PcStore.Data.Models
{
    public class AccessoryClient
    {
        public Guid AccessoryId { get; set; }
        public Accessory Accessory { get; set; } = null!;

        public Guid ClientId { get; set; }

        public ApplicationUser Client { get; set; } = null!;
    }
}

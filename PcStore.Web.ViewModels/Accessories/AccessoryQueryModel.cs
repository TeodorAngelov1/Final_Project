using PcStore.Web.ViewModels.Accessory;

namespace PcStore.Web.ViewModels.Accessories
{
    public class AccessoryQueryModel
    {
        public int CurrentPage { get; init; }

        public int AccessoriesPerPage { get; init; }

        public int TotalAccessories { get; init; }

        public IEnumerable<AllAccessoryModel> Accessories { get; init; }
    }
}

using PcStore.Web.ViewModels.Accessory;
using System.ComponentModel.DataAnnotations;
namespace PcStore.Web.ViewModels.Accessories
{
    public class AllQueryAccessoriesModel
    {
        public const int AccessoriesPerPage = 3;

        public string Brand { get; init; } = null!;

        [Display(Name = "Search by Brand")]
        public string SearchTerm { get; init; } = null!;

        public int CurrentPage { get; init; } = 1;

        public int TotalAccessories { get; set; }

        public IEnumerable<AllAccessoryModel> Accessories { get; set; } = new List<AllAccessoryModel>();
    }
}


using PcStore.Web.ViewModels.Part;
using System.ComponentModel.DataAnnotations;

namespace PcStore.Web.ViewModels.Part
{
    public class AllQueryPartsModel
    {
        public const int PartsPerPage = 3;

        public string Brand { get; init; } = null!;

        [Display(Name = "Search by Brand")]
        public string SearchTerm { get; init; } = null!;

        public int CurrentPage { get; init; } = 1;

        public int TotalParts { get; set; }

        public IEnumerable<AllPartModel> Parts { get; set; } = new List<AllPartModel>();
    }
}

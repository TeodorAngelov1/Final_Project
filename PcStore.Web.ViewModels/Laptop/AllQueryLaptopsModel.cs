using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcStore.Web.ViewModels.Laptop
{
    public class AllQueryLaptopsModel
    {
        public const int LaptopsPerPage = 3;

        public string Brand { get; init; } = null!;

        [Display(Name = "Search by Brand")]
        public string SearchTerm { get; init; } = null!;

        public int CurrentPage { get; init; } = 1;

        public int TotalLaptops { get; set; }

        public IEnumerable<AllLaptopsModel> Laptops { get; set; } = new List<AllLaptopsModel>();
    }
}

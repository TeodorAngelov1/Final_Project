using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcStore.Web.ViewModels.Laptop
{
    public class LaptopQueryModel
    {
        public int CurrentPage { get; init; }

        public int LaptopsPerPage { get; init; }

        public int TotalLaptops { get; init; }

        public IEnumerable<AllLaptopsModel> Laptops { get; init; }
    }
}

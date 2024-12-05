using PcStore.Web.ViewModels.Laptop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcStore.Web.ViewModels.Part
{
    public class PartQueryModel
    {
        public int CurrentPage { get; init; }

        public int PartsPerPage { get; init; }

        public int TotalParts { get; init; }

        public IEnumerable<AllPartModel> Parts { get; init; }
    }
}

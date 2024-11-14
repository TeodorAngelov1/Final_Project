using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcStore.Data.Models
{
    public class Laptop
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string LaptopName { get; set; } = null!;

        public string LaptopDescription { get; set; } = null!;

        public decimal LaptopPrice { get; set; }

        public string? LaptopImageUrl { get; set; }

        public IEnumerable<ProductLaptop> LaptopsProducts { get; set; } = new List<ProductLaptop>();

    }
}

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

        public string Brand { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public IEnumerable<LaptopClient> LaptopsClients { get; set; } = new List<LaptopClient>();

    }
}

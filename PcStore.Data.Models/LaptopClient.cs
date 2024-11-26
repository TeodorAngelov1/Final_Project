using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

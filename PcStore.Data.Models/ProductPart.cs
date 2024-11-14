using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcStore.Data.Models
{
    public class ProductPart
    {
        public Guid PartId { get; set; }

        public Part Part { get; set; } = null!;

        public Guid ProductId { get; set; }

        public Product Product { get; set; } = null!;

        public bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcStore.Data.Models
{
    public interface IProduct
    {
        Guid Id { get; set; }

        string Brand { get; set; }


        string Description { get; set; }


        decimal Price { get; set; }


        string? ImageUrl { get; set; }


        bool IsDeleted { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcStore.Web.ViewModels.Laptop
{
    public class DeleteLaptopModel
    {
        public string Id { get; set; } = null!;
        public string LaptopName { get; set; } = null!;

        [Required]
        public string Seller { get; set; } = string.Empty;

        [Required]
        public string SellerId { get; set; } = string.Empty;
    }
}

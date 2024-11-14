using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PcStore.Data.Models
{
    public class ProductClient
    {
        public Guid ProductId { get; set; }

        public Product Product { get; set; } = null!;

        public Guid ClientId { get; set; }

        public ApplicationUser Client { get; set; } = null!;
        public bool IsDeleted { get; set; }
    }
}



using System.ComponentModel.DataAnnotations;

namespace PcStore.Data.Models
{
    public class Category
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Name { get; set; } = null!;

        public IList<Product> Products { get; set; } = new List<Product>();
    }
}

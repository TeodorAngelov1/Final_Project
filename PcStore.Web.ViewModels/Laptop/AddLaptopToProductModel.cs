namespace PcStore.Web.ViewModels.Laptop
{
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Laptop;
    public class AddLaptopToProductModel 
    {
        [Required]
        public string Id { get; set; } = null!;

        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string LaptopName { get; set; } = null!;
    }
}

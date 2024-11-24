namespace PcStore.Web.ViewModels.Laptop
{
   
    using PcStore.Data.Models;
    using static Common.EntityValidationConstants.Laptop;
    using System.ComponentModel.DataAnnotations;
    
    public class EditLaptopModel 
    {
        [Required]
        [MaxLength(NameMaxLength)]
        [MinLength(NameMinLength)]
        public string LaptopName { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionMinLength)]
        public string LaptopDescription { get; set; } = null!;

        [Required]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal LaptopPrice { get; set; }

        public string? LaptopImageUrl { get; set; }
       
    }
}

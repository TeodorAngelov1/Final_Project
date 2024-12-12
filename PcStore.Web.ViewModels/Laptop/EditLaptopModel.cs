namespace PcStore.Web.ViewModels.Laptop
{
    using static Common.EntityValidationConstants;
    using System.ComponentModel.DataAnnotations;
    
    public class EditLaptopModel 
    {
        [Required]
        [MaxLength(BrandMaxLength)]
        [MinLength(BrandMinLength)]
        public string Brand { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }
       
    }
}

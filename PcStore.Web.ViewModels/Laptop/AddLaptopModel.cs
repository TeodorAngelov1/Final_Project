namespace PcStore.Web.ViewModels.Laptop
{
    using PcStore.Data.Models;
    using static Common.EntityValidationConstants.Laptop;
    using System.ComponentModel.DataAnnotations;

    public class AddPartModel 
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

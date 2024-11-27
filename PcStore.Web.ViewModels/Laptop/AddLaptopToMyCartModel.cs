namespace PcStore.Web.ViewModels.Laptop
{
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants.Laptop;
    public class AddLaptopToMyCartModel 
    {
        [Required]
        public string? Id { get; set; }


        [Required]
        [StringLength(BrandMaxLength, MinimumLength = BrandMinLength)]
        public string Brand { get; set; } = string.Empty;

        [Required]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        public string Seller { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        public IList<Laptop> Laptops { get; set; }
            = new List<Laptop>();
    }
}

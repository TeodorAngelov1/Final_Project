using System.ComponentModel.DataAnnotations;
using static PcStore.Common.EntityValidationConstants.MyCart;
namespace PcStore.Web.ViewModels.MyCart
{
    public class MyCartViewModel
    {
        [Required]
        public string Id { get; set; } = string.Empty;


        [Required]
        [StringLength(BrandMaxLength, MinimumLength = BrandMinLength)]
        public string ProductName { get; set; } = string.Empty;

        [Required]
        [Range(PriceMinValue, PriceMaxValue)]
        public decimal Price { get; set; }

        public string Seller { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;
    }
}

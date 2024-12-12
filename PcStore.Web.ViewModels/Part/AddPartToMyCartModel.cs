namespace PcStore.Web.ViewModels.Part
{
    using Data.Models;
    using System.ComponentModel.DataAnnotations;
    using static Common.EntityValidationConstants;
    public class AddPartToMyCartModel 
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

        public IList<Part> Parts { get; set; }
            = new List<Part>();
    }
}

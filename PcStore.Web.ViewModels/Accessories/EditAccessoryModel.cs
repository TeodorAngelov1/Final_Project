﻿namespace PcStore.Web.ViewModels.Accessory
{
    using static Common.EntityValidationConstants.Accessory;
    using System.ComponentModel.DataAnnotations;
    
    public class EditAccessoryModel 
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
﻿using System.ComponentModel.DataAnnotations;

namespace PcStore.Web.ViewModels.Accessory
{
    public class DeleteAccessoryModel
    {
        public string Id { get; set; } = null!;
        public string Brand { get; set; } = null!;

        [Required]
        public string Seller { get; set; } = string.Empty;

        [Required]
        public string SellerId { get; set; } = string.Empty;
    }
}
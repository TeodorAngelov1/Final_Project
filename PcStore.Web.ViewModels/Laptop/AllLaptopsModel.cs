﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace PcStore.Web.ViewModels.Laptop
{
    public class AllLaptopsModel 
    {
        public string Id { get; set; } = null!;

        public string Brand { get; set; } = null!;

        public string Description { get; set; } = null!;

        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }
    }
}

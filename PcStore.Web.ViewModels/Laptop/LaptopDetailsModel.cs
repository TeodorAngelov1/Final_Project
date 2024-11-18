﻿namespace PcStore.Web.ViewModels.Laptop
{
    using AutoMapper;

    using Data.Models;
    using Services.Mapping;
    public class LaptopDetailsModel : IMapFrom<Laptop>, IHaveCustomMappings
    {
        public string LaptopName { get; set; } = null!;

        public string LaptopDescription { get; set; } = null!;

        public decimal LaptopPrice { get; set; }

        public string? LaptopImageUrl { get; set; }
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Laptop, LaptopDetailsModel>()
               .ForMember(x => x.LaptopImageUrl,
                   x => x.MapFrom(s => s.LaptopImageUrl));
        }
    }
}
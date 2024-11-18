namespace PcStore.Web.ViewModels.Laptop
{
    using AutoMapper;
    using PcStore.Services.Mapping;
    using PcStore.Data.Models;
    using static Common.EntityValidationConstants.Laptop;
    using System.ComponentModel.DataAnnotations;

    public class AddLaptopModel : IMapTo<Laptop>, IHaveCustomMappings
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
        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<AddLaptopModel, Laptop>()
                .ForMember(d => d.LaptopImageUrl, x => x.Ignore());
        }
    }
}

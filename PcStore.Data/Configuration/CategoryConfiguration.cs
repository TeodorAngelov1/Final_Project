namespace PcStore.Data.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using PcStore.Data.Models;
    using static Common.EntityValidationConstants.Category;
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(NameMaxLength);

            builder.HasData(this.GenerateCategories());
        }
        private IEnumerable<Category> GenerateCategories()
        {
            IEnumerable<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Name = "Parts"
                },
                new Category()
                {
                    Name = "Laptops"
                }
            };

            return categories;
        }
    }
}

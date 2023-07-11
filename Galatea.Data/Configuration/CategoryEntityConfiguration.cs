using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Galatea.Data.Models;

namespace Galatea.Data.Configuration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasData(this.GenerateCategories());
        }

        private Category[] GenerateCategories()
        {
            ICollection<Category> categories = new HashSet<Category>();

            Category category;

            category = new Category()
            {
                Id = 1,
                Name = "Обява"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 2,
                Name = "Търся"
            };
            categories.Add(category);

            category = new Category()
            {
                Id = 3,
                Name = "Предлагам"
            };
            categories.Add(category);

            return categories.ToArray();
        }
    }
}

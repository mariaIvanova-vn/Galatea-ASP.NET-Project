using System.ComponentModel.DataAnnotations;

using static Galatea.Common.EntityValidationConstants.Category;

namespace Galatea.Data.Models
{
    public class Category
    {
        public Category()
        {
                this.Publications = new HashSet<Publication>();
        }
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

       
        public virtual ICollection<Publication> Publications { get; set; }
    }
}
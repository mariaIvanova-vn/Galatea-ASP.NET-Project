using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Galatea.Data.Models;
using static Galatea.Common.EntityValidationConstants;
using Publication = Galatea.Data.Models.Publication;
using Comment = Galatea.Data.Models.Comment;

namespace Galatea.Data.Configuration
{
    public class GalateaEntityConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
            builder.Property(p => p.CreatedOn).HasDefaultValueSql("GETDATE()");

            builder.Property(p => p.IsActive).HasDefaultValue(true);

            builder.HasOne(p=>p.Category)
                .WithMany(c=>c.Publications)
                .HasForeignKey(p=>p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p=>p.User)
                .WithMany(u=>u.UsersPublications)
                .HasForeignKey(p=>p.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c=>c.Comments)
                .WithOne(p=>p.Publication)
                .HasForeignKey(p=>p.PublicationId) 
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GeneratePublication());
            builder.HasData(this.GenerateComment());
        }

        private Comment[] GenerateComment()
        {
            ICollection<Comment> comments = new HashSet<Comment>();

            return comments.ToArray();
        }

        private Publication[] GeneratePublication()
        {
            ICollection<Publication> publications = new HashSet<Publication>();

            Publication publication;

            publication = new Publication()
            {
                Title = "Търся персонал",
                Content = "Квартален магазин за хранителни стоки търси персонал. За повече информация - 0888888888",
                ImageUrl = "https://www.24x7.place/media/images/objects/2017/1513689955-SN850672.JPG",
                CreatedOn = DateTime.Now,
                CategoryId = 2,
                Comments = new List<Comment>(),
                //Rating = new List<Rating>(),
                UserId = Guid.Parse("2F0FF2D4-B657-4CB5-3C99-08DB81F0BBC7")
            };
            publications.Add(publication);                     

            return publications.ToArray();
        }
    }
}

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

            builder.HasOne(p => p.Category)
                .WithMany(c => c.Publications)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(p => p.User)
                .WithMany(u => u.UsersPublications)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(p => p.Rating)
                .WithOne(r => r.Publication)
                .HasForeignKey(p => p.Id)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Comments)
                .WithOne(c => c.Publication)
                .HasForeignKey(p => p.PublicationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(this.GeneratePublication());
            //builder.HasData(this.GenerateComment());
        }

        //private Comment[] GenerateComment()
        //{
        //    ICollection<Comment> comments = new HashSet<Comment>();
        //    Comment comment;
        //    comment = new Comment()
        //    {
        //        Text = "...........",
        //        PublicationId = Guid.Parse("3FCCDF54-22C5-47F2-AB6A-FC987D16D704"),
        //        UserId = Guid.Parse("3FCCDF54-22C5-47F2-AB6A-FC987D16D704")
        //    };

        //    comments.Add(comment);
        //    return comments.ToArray();
        //}

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
                IsActive = true,
                CategoryId = 2,
                Comments = new List<Comment>(),
                //Rating = new List<Rating>(),
                UserId = Guid.Parse("4305F537-DF35-473E-AEBC-97C32ADE996C")
            };
            publications.Add(publication);

            return publications.ToArray();
        }
    }
}

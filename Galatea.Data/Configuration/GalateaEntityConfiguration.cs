using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using Galatea.Data.Models;

namespace Galatea.Data.Configuration
{
    public class GalateaEntityConfiguration : IEntityTypeConfiguration<Publication>
    {
        public void Configure(EntityTypeBuilder<Publication> builder)
        {
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
        }        
    }
}

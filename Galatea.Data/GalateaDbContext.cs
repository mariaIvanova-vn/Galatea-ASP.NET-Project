using Galatea.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Galatea.Web.Data
{
    public class GalateaDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        private readonly bool seedDb;

        public GalateaDbContext(DbContextOptions<GalateaDbContext> options, bool seedDb = true)
            : base(options)
        {
            this.seedDb = seedDb;
        }

        public DbSet<Category> Categories { get; set; } = null!;

        public DbSet<Response> Responses { get; set; } = null!;

        public DbSet<Publication> Publications { get; set; } = null!;

        public DbSet<Comment> Comments { get; set; } = null!;

        public DbSet<Rating> Ratings { get; set; } = null!;

        public DbSet<UserResponse> UserResponses { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder builder)
        {
            Assembly configAssembly = Assembly.GetAssembly(typeof(GalateaDbContext)) ??
                                      Assembly.GetExecutingAssembly();
            builder.ApplyConfigurationsFromAssembly(configAssembly);

            base.OnModelCreating(builder);
        }      
    }
}
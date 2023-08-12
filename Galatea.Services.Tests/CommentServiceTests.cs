using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Galatea.Services.Tests.DatabaseSeeder;
using Galatea.Services.Data;
using Galatea.Web.ViewModels.Publication;
using NUnit.Framework.Constraints;
using static Galatea.Common.EntityValidationConstants;
using Galatea.Services.Data.Interfaces;
using Galatea.Web.Data;
using Microsoft.EntityFrameworkCore;
using Galatea.Web.ViewModels.Comments;

namespace Galatea.Services.Tests
{
    public class CommentServiceTests
    {
        private DbContextOptions<GalateaDbContext> dbOptions;
        private GalateaDbContext dbContext;

        private ICommentsService commentsService;

        [SetUp]
        public void Setup()
        {
            this.dbOptions = new DbContextOptionsBuilder<GalateaDbContext>()
                .UseInMemoryDatabase("GalateaInMemoryDb" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new GalateaDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.commentsService = new CommentsService(this.dbContext);
        }

        [Test]
        public async Task AllByPublicationIdAsync()
        {
            var publicationId = Guid.Parse("898BC7B9-B563-43F4-A2A9-462873BAAD61");

            var allPublicationComments = await this.dbContext
                .Comments.AnyAsync(c => c.PublicationId == publicationId);

            Assert.IsTrue(allPublicationComments);
        }

        [Test]
        public async Task GetCommentByUserIdAsync()
        {
            var userId = Guid.Parse("5A2BC7E4-B447-42C8-AF8E-E27B9B0C5DD5");

            var comment = await this.dbContext.Comments
                    .FirstAsync(x => x.UserId == userId);

            Assert.That("искам", Is.EqualTo(comment.Text));
            Assert.That(comment.UserId, Is.EqualTo(userId));
        }
    }
}

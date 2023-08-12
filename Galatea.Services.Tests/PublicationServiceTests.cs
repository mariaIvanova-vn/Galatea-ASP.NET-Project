using Galatea.Data.Models;
using Galatea.Data;
using Galatea.Services.Data.Interfaces;
using Galatea.Web.Data;
using Microsoft.EntityFrameworkCore;
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

namespace Galatea.Services.Tests
{
    public class PublicationServiceTests
    {
        private DbContextOptions<GalateaDbContext> dbOptions;
        private GalateaDbContext dbContext;

        private IPublicationService publicationService;



        [SetUp]
        public void Setup()
        {
            this.dbOptions = new DbContextOptionsBuilder<GalateaDbContext>()
                .UseInMemoryDatabase("GalateaInMemoryDb" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new GalateaDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.publicationService = new PublicationService(this.dbContext);
        }

        [Test]
        public async Task AllByUserIdAsync()
        {
            var userId = Guid.Parse("5A2BC7E4-B447-42C8-AF8E-E27B9B0C5DD5");

            var allUserPublications = await this.dbContext
                .Publications.Where(p => p.IsActive).Where(p => p.UserId == userId)
                .ToArrayAsync();

            Assert.IsTrue(allUserPublications.Any());
        }

        [Test]
        public async Task ExistByIdAsyncReturnTrue()
        {
            var publicationId = Guid.Parse("898BC7B9-B563-43F4-A2A9-462873BAAD61");

            bool result = await this.dbContext.Publications.Where(p => p.IsActive)
                .AnyAsync(p => p.Id == publicationId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task ExistByIdAsyncReturnFalse()
        {
            var publicationId = Guid.Parse("898BC7B0-B563-43F4-A2A9-462873BAAD61");

            bool result = await this.dbContext.Publications.Where(p => p.IsActive)
                .AnyAsync(p => p.Id == publicationId);

            Assert.IsFalse(result);
        }


        [Test]
        public async Task IsUserPublicationOwnerAsyncReturnTrue()
        {
            var publicationId = Guid.Parse("1FFD0F48-E21E-4F0C-BDA4-9F6B484F5751");
            var userId = Guid.Parse("5A2BC7E4-B447-42C8-AF8E-E27B9B0C5DD5");

            bool isOwner = await dbContext.
                Publications.
                AnyAsync(c => c.Id == publicationId && c.UserId == userId);

            Assert.IsTrue(isOwner);
        }
        [Test]
        public async Task IsUserPublicationOwnerAsyncReturnFalse()
        {
            var publicationId = Guid.Parse("1FFD0F46-E21E-4F0C-BDA4-9F6B484F5751");
            var userId = Guid.Parse("5A2BC7E4-B447-42C8-AF8E-E27B9B0C5DD5");

            bool isOwner = await dbContext.
                Publications.
                AnyAsync(c => c.Id == publicationId && c.UserId == userId);

            Assert.IsFalse(isOwner);
        }

        [Test]
        public async Task GetDetailsByIdAsyncReturnTrue()
        {
            var publicationId = Guid.Parse("898BC7B9-B563-43F4-A2A9-462873BAAD61");

            var publication = await this.dbContext.Publications.Where(p => p.IsActive)
                .FirstAsync(p => p.Id == publicationId);

            Assert.IsTrue(publication.Title == "продавам мед");
        }

        [Test]
        public async Task GetDetailsByIdAsyncReturnFalse()
        {
            var publicationId = Guid.Parse("898BC7B9-B563-43F4-A2A9-462873BAAD61");

            var publication = await this.dbContext.Publications.Where(p => p.IsActive)
                .FirstAsync(p => p.Id == publicationId);

            Assert.IsFalse(publication.Title == "мед");
        }
    }
}

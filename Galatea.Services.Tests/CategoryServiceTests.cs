using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Galatea.Services.Tests.DatabaseSeeder;
using Galatea.Services.Data;
using NUnit.Framework.Constraints;
using static Galatea.Common.EntityValidationConstants;
using Galatea.Services.Data.Interfaces;
using Galatea.Web.Data;
using Microsoft.EntityFrameworkCore;

namespace Galatea.Services.Tests
{
    public class CategoryServiceTests
    {
        private DbContextOptions<GalateaDbContext> dbOptions;
        private GalateaDbContext dbContext;

        private ICategoryService categoryService;



        [SetUp]
        public void Setup()
        {
            this.dbOptions = new DbContextOptionsBuilder<GalateaDbContext>()
                .UseInMemoryDatabase("GalateaInMemoryDb" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new GalateaDbContext(this.dbOptions);

            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.categoryService = new CategoryService(this.dbContext);
        }

        [Test]
        public async Task ExistIdAsyncReturnTrue()
        {
            var categoryId = 1;

            bool result = await this.dbContext.Categories.AnyAsync(c => c.Id == categoryId);

            Assert.IsTrue(result);
        }

        [Test]
        public async Task AllCategoryNamesAsync()
        {
            var categoryNames = await this.dbContext.Categories.Select(c => c.Name).ToListAsync();
             var categoryName = categoryNames.FirstOrDefault(categoryNames.Contains);    

            Assert.That("Обява", Is.EqualTo(categoryName));
        }
    }
}

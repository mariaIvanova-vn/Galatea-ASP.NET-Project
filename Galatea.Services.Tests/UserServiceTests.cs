using Galatea.Services.Data;
using Galatea.Services.Data.Interfaces;
using Galatea.Web.Data;
using Microsoft.EntityFrameworkCore;

using static Galatea.Services.Tests.DatabaseSeeder;

namespace Galatea.Services.Tests
{
    public class UserServiceTests
    {
        private DbContextOptions<GalateaDbContext> dbOptions;
        private GalateaDbContext dbContext;

        private IUsersService usersService;


        [SetUp]
        public void Setup()
        {
            this.dbOptions = new DbContextOptionsBuilder<GalateaDbContext>()
                .UseInMemoryDatabase("GalateaInMemoryDb" + Guid.NewGuid().ToString())
                .Options;
            this.dbContext = new GalateaDbContext(this.dbOptions);


            this.dbContext.Database.EnsureCreated();
            SeedDatabase(this.dbContext);

            this.usersService = new UsersService(this.dbContext);
        }

        [Test]
        public async Task GetUserCount()
        {
            var userCount = await dbContext.Users.CountAsync();

            Assert.IsFalse(await dbContext.Users.AnyAsync());           
        }

    }
}
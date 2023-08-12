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
        public async Task GetUserCountReturnTrue()
        {
            var userCount = await dbContext.Users.CountAsync();

            Assert.IsTrue(await dbContext.Users.AnyAsync());
            Assert.IsFalse(userCount == 0);
        }

        [Test]
        public async Task GetUser()
        {
            var userId = Guid.Parse("5A2BC7E4-B447-42C8-AF8E-E27B9B0C5DD5");

            var user = await this.dbContext.Users.FirstAsync(x => x.Id == userId);

            Assert.IsNotNull(user);

            Assert.IsTrue(user.Id == userId);
        }
    }
}
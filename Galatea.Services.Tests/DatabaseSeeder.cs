using Galatea.Data;
using Galatea.Data.Models;
using Galatea.Web.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Galatea.Services.Tests
{
    public static class DatabaseSeeder
    {
        public static AppUser User1 = null!;
        public static AppUser User2 = null!;

        public static Publication Publication1 = null!;
        public static Publication Publication2 = null!;

        public static List<Publication> Publications = 
            new List<Publication>() { Publication1, Publication2 };

        public static void SeedDatabase(GalateaDbContext dbContext)
        {
            User1 = new AppUser
            {
                Id = Guid.Parse("4305F537-DF35-473E-AEBC-97C32ADE996C"),
                UserName = "userDidi@user.com",
                NormalizedUserName = "USERDIDI@USER.COM",
                Email = "userDidi@user.com",
                NormalizedEmail = "USERDIDI@USER.COM",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAEOxlQgSCpzugYvhTuRKWodNWiA145pUK0Owh19bJbdnRn8bRWt9k1u1vexD20dZwmQ==",
                SecurityStamp = "TYLFAPLAGF2QLJTU3FJ3ZVI6YNFACIDR",
                ConcurrencyStamp = "e33b34d6-b43a-4b0b-b228-76cbd9906acd",
                TwoFactorEnabled = false
            };

            User2 = new AppUser
            {
                Id = Guid.Parse("5A2BC7E4-B447-42C8-AF8E-E27B9B0C5DD5"),
                UserName = "test@abv.bg",
                NormalizedUserName = "TEST@ABV.BG",
                Email = "test@abv.bg",
                NormalizedEmail = "TEST@ABV.BG",
                EmailConfirmed = true,
                PasswordHash = "AQAAAAEAACcQAAAAELJyhFACBnjRyLAAKMOlBGIIQVXwa5PVF26VTyc8bfeMNJBRTcKALKYglw7A7ORggw==",
                SecurityStamp = "C6ZRDSQM2DDHZNQVS4IFX553FPYAIZ4C",
                ConcurrencyStamp = "b6d4a4cb-0014-4705-95ec-5cfce28374cc",
                TwoFactorEnabled = false
            };

            Publication1 = new Publication
            {
                Id = Guid.Parse("1FFD0F48-E21E-4F0C-BDA4-9F6B484F5751"),
                Title = "Лятна занималня",
                Content = "Ваканция в читалище \"Васил Левски\" - кв. Галата",
                ImageUrl = "https://scontent-sof1-2.xx.fbcdn.net/v/t39.30808-6/363300011_2614774378673195_2898190749418567464_n.jpg?_nc_cat=110&ccb=1-7&_nc_sid=730e14&_nc_ohc=9Zpz9UBYNhUAX-vd1Md&_nc_ht=scontent-sof1-2.xx&oh=00_AfAEsqx8SfrX823_2uEMUAYWCf1tEj5SNHO9ps-VIVX2ZQ&oe=64D9D80A",
                CreatedOn = DateTime.Now,
                IsActive = true,
                CategoryId = 1,
                UserId = Guid.Parse("5A2BC7E4-B447-42C8-AF8E-E27B9B0C5DD5"),
            };
            Publication2 = new Publication
            {
                Id = Guid.Parse("898BC7B9-B563-43F4-A2A9-462873BAAD61"),
                Title = "продавам мед",
                Content = "продавам домашен мед от липа",
                ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSTp44aTjOS5K8k5hG1EfI3d9JLojqYKYtfb9V7vHVOUjp2mxpDy2ZZEuzjNCF943NvpCo&usqp=CAU",
                CreatedOn = DateTime.Now,
                IsActive = true,
                CategoryId = 3,
                UserId = Guid.Parse("4305F537-DF35-473E-AEBC-97C32ADE996C"),
            };
            dbContext.Users.Add(User1);
            dbContext.Users.Add(User2);
            dbContext.Publications.AddRange(Publication1, Publication2);

            dbContext.SaveChanges();
        }       
    }
}

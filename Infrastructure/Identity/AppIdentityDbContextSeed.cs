using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Identity;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if(!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Maks",
                    Email = "maks19801@gmail.com",
                    UserName = "maks19801@gmail.com",
                    Address = new Address
                    {
                        FirstName = "Maks",
                        LastName = "Porsh",
                        Street = "Voroshilova",
                        City = "Kherson",
                        State = "Khersonska",
                        ZipCode = "73000"
                    }
                };
                
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }          
        }
    }
}
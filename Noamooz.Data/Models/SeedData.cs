using Microsoft.Extensions.DependencyInjection;
using Noamooz.Core.Models;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace Noamooz.Data.Models
{
    public static class SeedData
    {
        public static async void CreateData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            //ApplicationDbContext context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            UserManager<IdentityUser> _userManagent = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

            var exist = _userManagent.FindByNameAsync("Admin");
            if (exist == null)
            {
                var user = new IdentityUser("Admin");
                await _userManagent.CreateAsync(user, "123456");
                await _userManagent.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Domex.Core.Application.Enums;
using Domex.Infrastructure.Identity.Entities;

namespace Domex.Infrastructure.Identity.Seeds
{
    public static class DefaulAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser defaultUser = new()
            {
                Id = "2d124d85-4239-4c56-b1a8-b5a59c2c7d12",
                UserName = "adminuser",
                Email = "adminuser@email.com",
                FirstName = "Jake",
                LastName = "Doe",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            if (userManager.Users.All(u => u.Id != defaultUser.Id))
            {
                var user = await userManager.FindByEmailAsync(defaultUser.Email);

                if (user == null)
                {
                    await userManager.CreateAsync(defaultUser, "123P4$$w0rd!");
                    await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
                }
            }
        }
    }
}

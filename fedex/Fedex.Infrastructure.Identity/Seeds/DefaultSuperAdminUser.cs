using Microsoft.AspNetCore.Identity;
using Fedex.Core.Application.Enums;
using Fedex.Infrastructure.Identity.Entities;

namespace Fedex.Infrastructure.Identity.Seeds
{
    public static class DefaulSuperAdminUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser superAdminUser = new()
            {
                UserName = "superadminuser",
                Email = "superadminuser@email.com",
                FirstName = "Jane",
                LastName = "Doe",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };

            if (userManager.Users.All(u => u.Id != superAdminUser.Id))
            {
                var user = await userManager.FindByEmailAsync(superAdminUser.Email);

                if (user == null)
                {
                    await userManager.CreateAsync(superAdminUser, "123P4$$w0rd!");
                    await userManager.AddToRoleAsync(superAdminUser, Roles.Admin.ToString());
                    await userManager.AddToRoleAsync(superAdminUser, Roles.Partner.ToString());
                    await userManager.AddToRoleAsync(superAdminUser, Roles.SuperAdmin.ToString());
                }
            }
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Fedex.Core.Application.Enums;
using Fedex.Infrastructure.Identity.Entities;

namespace Fedex.Infrastructure.Identity.Seeds
{
    public static class DefaulPartnerUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser defaultUser = new()
            {
                Id = "34796422-cda8-4aa2-bc8a-cdc567efae06",
                UserName = "agentuser",
                Email = "agentuser@email.com",
                FirstName = "Jules",
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
                    await userManager.AddToRoleAsync(defaultUser, Roles.Partner.ToString());
                }
            }
        }
    }
}

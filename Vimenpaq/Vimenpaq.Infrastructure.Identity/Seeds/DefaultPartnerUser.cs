using Microsoft.AspNetCore.Identity;
using Vimenpaq.Core.Application.Enums;
using Vimenpaq.Infrastructure.Identity.Entities;

namespace Vimenpaq.Infrastructure.Identity.Seeds
{
    public static class DefaulPartnerUser
    {
        public static async Task SeedAsync(UserManager<ApplicationUser> userManager)
        {
            ApplicationUser defaultUser = new()
            {
                Id = "34796422-cda8-4aa2-bc8a-cdc567efae06",
                UserName = "partneruser",
                Email = "partneruser@email.com",
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

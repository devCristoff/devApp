using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Vimenpaq.Infrastructure.Identity.Entities;
using Vimenpaq.Infrastructure.Identity.Seeds;

namespace Vimenpaq.Infrastructure.Identity
{
    //Design pattern --> Decorator - Extensions methods
    public static class ServiceApplication
    {
        public static async Task AddIdentitySeeds(this IServiceProvider services)
        {
            #region "Identity Seeds"
            using (var scope = services.CreateScope())
            {
                var serviceScope = scope.ServiceProvider;

                try
                {
                    var userManager = serviceScope.GetRequiredService<UserManager<ApplicationUser>>();
                    var roleManager = serviceScope.GetRequiredService<RoleManager<IdentityRole>>();

                    await DefaultRoles.SeedAsync(roleManager);
                    await DefaulSuperAdminUser.SeedAsync(userManager);
                    await DefaulAdminUser.SeedAsync(userManager);
                    await DefaulPartnerUser.SeedAsync(userManager);
                }
                catch (Exception ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine(ex.Message.ToString());
                    Console.ResetColor();
                }
            }
            #endregion
        }
    }
}

namespace CookLab.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CookLab.Common;
    using CookLab.Data.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;

    internal class UsersSeeder : ISeeder
    {
        private ApplicationUser administrator = new ApplicationUser
        {
            UserName = GlobalConstants.AdministratorUsername,
            Email = GlobalConstants.AdinistratorEmail,
        };

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();

            await SeedUserAsync(userManager, this.administrator);
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, ApplicationUser administrator)
        {
            var user = await userManager.FindByNameAsync(administrator.UserName);
            if (user == null)
            {
                var result = await userManager.CreateAsync(administrator, GlobalConstants.AdministratorPassword);
                var adminUser = await userManager.FindByNameAsync(GlobalConstants.AdministratorUsername);
                await userManager.AddToRoleAsync(adminUser, GlobalConstants.AdministratorRoleName);
                if (!result.Succeeded)
                {
                    throw new Exception(string.Join(Environment.NewLine, result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}

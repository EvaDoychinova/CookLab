namespace CookLab.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    public class ApplicationDbContextSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            if (serviceProvider == null)
            {
                throw new ArgumentNullException(nameof(serviceProvider));
            }

            var logger = serviceProvider.GetService<ILoggerFactory>().CreateLogger(typeof(ApplicationDbContextSeeder));

            var cookingVesselsSeeder = new CookingVesselsSeeder();
            await cookingVesselsSeeder.SeedAsync(dbContext, serviceProvider);
            await dbContext.Database.OpenConnectionAsync();
            try
            {
                await dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.CookingVessels ON");
                await dbContext.SaveChangesAsync();
                await dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.CookingVessels OFF");
            }
            finally
            {
                await dbContext.Database.CloseConnectionAsync();
            }

            logger.LogInformation($"Seeder {cookingVesselsSeeder.GetType().Name} done.");

            var categoriesSeeder = new CategoriesSeeder();
            await categoriesSeeder.SeedAsync(dbContext, serviceProvider);
            await dbContext.Database.OpenConnectionAsync();
            try
            {
                await dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Categories ON");
                await dbContext.SaveChangesAsync();
                await dbContext.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT dbo.Categories OFF");
            }
            finally
            {
                await dbContext.Database.CloseConnectionAsync();
            }

            logger.LogInformation($"Seeder {categoriesSeeder.GetType().Name} done.");

            var seeders = new List<ISeeder>
                          {
                              new RolesSeeder(),
                              new UsersSeeder(),
                              new IngredientsSeeder(),
                              new RecipesSeeder(),
                          };

            foreach (var seeder in seeders)
            {
                await seeder.SeedAsync(dbContext, serviceProvider);
                await dbContext.SaveChangesAsync();
                logger.LogInformation($"Seeder {seeder.GetType().Name} done.");
            }
        }
    }
}

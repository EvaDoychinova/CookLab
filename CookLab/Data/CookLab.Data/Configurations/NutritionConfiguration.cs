namespace CookLab.Data.Configurations
{
    using CookLab.Data.Models;

    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class NutritionConfiguration : IEntityTypeConfiguration<Nutrition>
    {
        public void Configure(EntityTypeBuilder<Nutrition> nutrition)
        {
            nutrition
                .HasOne(n => n.Ingredient)
                .WithOne(i => i.NutritionPer100Grams)
                .HasForeignKey<Nutrition>(n => n.IngredientId);

            nutrition
                .HasOne(n => n.Recipe)
                .WithOne(r => r.NutritionPer100Grams)
                .HasForeignKey<Nutrition>(n => n.RecipeId);
        }
    }
}

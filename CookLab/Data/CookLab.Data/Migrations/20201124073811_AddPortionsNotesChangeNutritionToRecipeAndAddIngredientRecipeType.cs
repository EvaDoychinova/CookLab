namespace CookLab.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddPortionsNotesChangeNutritionToRecipeAndAddIngredientRecipeType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Recipes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Portions",
                table: "Recipes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "RecipeIngredients",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Portions",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "RecipeIngredients");
        }
    }
}

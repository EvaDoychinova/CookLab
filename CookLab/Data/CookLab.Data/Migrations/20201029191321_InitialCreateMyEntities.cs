namespace CookLab.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitialCreateMyEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormDimensions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    Diameter = table.Column<double>(nullable: false),
                    SideA = table.Column<double>(nullable: false),
                    SideB = table.Column<double>(nullable: false),
                    Height = table.Column<double>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormDimensions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CookingVessels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Form = table.Column<int>(nullable: false),
                    FormDimensionId = table.Column<int>(nullable: false),
                    Volume = table.Column<double>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CookingVessels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CookingVessels_FormDimensions_FormDimensionId",
                        column: x => x.FormDimensionId,
                        principalTable: "FormDimensions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    CookingVesselId = table.Column<int>(nullable: false),
                    Preparation = table.Column<string>(nullable: true),
                    NutritionId = table.Column<string>(nullable: true),
                    CreatorId = table.Column<string>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipes_CookingVessels_CookingVesselId",
                        column: x => x.CookingVesselId,
                        principalTable: "CookingVessels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipes_AspNetUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CategoryRecipes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    RecipeId = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryRecipes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CategoryRecipes_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CategoryRecipes_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserRecipe",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<string>(nullable: true),
                    RecipeId = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRecipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRecipe_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserRecipe_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Nutritions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Calories = table.Column<double>(nullable: false),
                    Carbohydrates = table.Column<double>(nullable: false),
                    Fats = table.Column<double>(nullable: false),
                    Proteins = table.Column<double>(nullable: false),
                    Fibres = table.Column<double>(nullable: false),
                    IngredientId = table.Column<string>(nullable: true),
                    RecipeId = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nutritions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Nutritions_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    VolumePer100Grams = table.Column<double>(nullable: false),
                    NutritionId = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Nutritions_NutritionId",
                        column: x => x.NutritionId,
                        principalTable: "Nutritions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredients",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IngredientId = table.Column<string>(nullable: false),
                    RecipeId = table.Column<string>(nullable: false),
                    WeightInGrams = table.Column<double>(nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeIngredients_Recipes_RecipeId",
                        column: x => x.RecipeId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_IsDeleted",
                table: "Categories",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRecipes_CategoryId",
                table: "CategoryRecipes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRecipes_RecipeId",
                table: "CategoryRecipes",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_CookingVessels_FormDimensionId",
                table: "CookingVessels",
                column: "FormDimensionId");

            migrationBuilder.CreateIndex(
                name: "IX_CookingVessels_IsDeleted",
                table: "CookingVessels",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_IsDeleted",
                table: "Ingredients",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_NutritionId",
                table: "Ingredients",
                column: "NutritionId");

            migrationBuilder.CreateIndex(
                name: "IX_Nutritions_IngredientId",
                table: "Nutritions",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Nutritions_IsDeleted",
                table: "Nutritions",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_Nutritions_RecipeId",
                table: "Nutritions",
                column: "RecipeId",
                unique: true,
                filter: "[RecipeId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IngredientId",
                table: "RecipeIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_IsDeleted",
                table: "RecipeIngredients",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredients_RecipeId",
                table: "RecipeIngredients",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CookingVesselId",
                table: "Recipes",
                column: "CookingVesselId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_CreatorId",
                table: "Recipes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipes_IsDeleted",
                table: "Recipes",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserRecipe_IsDeleted",
                table: "UserRecipe",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_UserRecipe_RecipeId",
                table: "UserRecipe",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRecipe_UserId",
                table: "UserRecipe",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Nutritions_Ingredients_IngredientId",
                table: "Nutritions",
                column: "IngredientId",
                principalTable: "Ingredients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Nutritions_Recipes_RecipeId",
                table: "Nutritions");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Nutritions_NutritionId",
                table: "Ingredients");

            migrationBuilder.DropTable(
                name: "CategoryRecipes");

            migrationBuilder.DropTable(
                name: "RecipeIngredients");

            migrationBuilder.DropTable(
                name: "UserRecipe");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "CookingVessels");

            migrationBuilder.DropTable(
                name: "FormDimensions");

            migrationBuilder.DropTable(
                name: "Nutritions");

            migrationBuilder.DropTable(
                name: "Ingredients");
        }
    }
}

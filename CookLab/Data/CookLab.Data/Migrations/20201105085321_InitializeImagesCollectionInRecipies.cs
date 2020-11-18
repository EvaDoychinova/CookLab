namespace CookLab.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class InitializeImagesCollectionInRecipies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookingVessels_FormDimensions_VesselDimensionId",
                table: "CookingVessels");

            migrationBuilder.DropForeignKey(
                name: "FK_Ingredients_Nutritions_NutritionId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_Nutritions_IngredientId",
                table: "Nutritions");

            migrationBuilder.DropIndex(
                name: "IX_Ingredients_NutritionId",
                table: "Ingredients");

            migrationBuilder.DropIndex(
                name: "IX_CookingVessels_IsDeleted",
                table: "CookingVessels");

            migrationBuilder.DropIndex(
                name: "IX_CookingVessels_VesselDimensionId",
                table: "CookingVessels");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FormDimensions",
                table: "FormDimensions");

            migrationBuilder.DropColumn(
                name: "NutritionId",
                table: "Recipes");

            migrationBuilder.DropColumn(
                name: "NutritionId",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "VolumePer100Grams",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "CookingVessels");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CookingVessels");

            migrationBuilder.DropColumn(
                name: "VesselDimensionId",
                table: "CookingVessels");

            migrationBuilder.RenameTable(
                name: "FormDimensions",
                newName: "VesselDimensions");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VolumeInMlPer100Grams",
                table: "Ingredients",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CookingVesselId",
                table: "VesselDimensions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VesselDimensions",
                table: "VesselDimensions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Nutritions_IngredientId",
                table: "Nutritions",
                column: "IngredientId",
                unique: true,
                filter: "[IngredientId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_VesselDimensions_CookingVesselId",
                table: "VesselDimensions",
                column: "CookingVesselId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VesselDimensions_CookingVessels_CookingVesselId",
                table: "VesselDimensions",
                column: "CookingVesselId",
                principalTable: "CookingVessels",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VesselDimensions_CookingVessels_CookingVesselId",
                table: "VesselDimensions");

            migrationBuilder.DropIndex(
                name: "IX_Nutritions_IngredientId",
                table: "Nutritions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VesselDimensions",
                table: "VesselDimensions");

            migrationBuilder.DropIndex(
                name: "IX_VesselDimensions_CookingVesselId",
                table: "VesselDimensions");

            migrationBuilder.DropColumn(
                name: "VolumeInMlPer100Grams",
                table: "Ingredients");

            migrationBuilder.DropColumn(
                name: "CookingVesselId",
                table: "VesselDimensions");

            migrationBuilder.RenameTable(
                name: "VesselDimensions",
                newName: "FormDimensions");

            migrationBuilder.AddColumn<string>(
                name: "NutritionId",
                table: "Recipes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Ingredients",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<string>(
                name: "NutritionId",
                table: "Ingredients",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "VolumePer100Grams",
                table: "Ingredients",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "CookingVessels",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CookingVessels",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "VesselDimensionId",
                table: "CookingVessels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ImageUrl",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FormDimensions",
                table: "FormDimensions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Nutritions_IngredientId",
                table: "Nutritions",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_NutritionId",
                table: "Ingredients",
                column: "NutritionId");

            migrationBuilder.CreateIndex(
                name: "IX_CookingVessels_IsDeleted",
                table: "CookingVessels",
                column: "IsDeleted");

            migrationBuilder.CreateIndex(
                name: "IX_CookingVessels_VesselDimensionId",
                table: "CookingVessels",
                column: "VesselDimensionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CookingVessels_FormDimensions_VesselDimensionId",
                table: "CookingVessels",
                column: "VesselDimensionId",
                principalTable: "FormDimensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ingredients_Nutritions_NutritionId",
                table: "Ingredients",
                column: "NutritionId",
                principalTable: "Nutritions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

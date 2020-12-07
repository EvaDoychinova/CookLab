namespace CookLab.Data.Migrations
{
    using System;

    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddContactFormEntityToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipe_Recipes_RecipeId",
                table: "UserRecipe");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipe_AspNetUsers_UserId",
                table: "UserRecipe");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRecipe",
                table: "UserRecipe");

            migrationBuilder.RenameTable(
                name: "UserRecipe",
                newName: "UserRecipes");

            migrationBuilder.RenameIndex(
                name: "IX_UserRecipe_UserId",
                table: "UserRecipes",
                newName: "IX_UserRecipes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRecipe_RecipeId",
                table: "UserRecipes",
                newName: "IX_UserRecipes_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRecipe_IsDeleted",
                table: "UserRecipes",
                newName: "IX_UserRecipes_IsDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CookingVessels",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRecipes",
                table: "UserRecipes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    Title = table.Column<string>(maxLength: 100, nullable: false),
                    Message = table.Column<string>(maxLength: 2147483647, nullable: false),
                    IpAddress = table.Column<string>(maxLength: 39, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_IsDeleted",
                table: "Contacts",
                column: "IsDeleted");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipes_Recipes_RecipeId",
                table: "UserRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipes_AspNetUsers_UserId",
                table: "UserRecipes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipes_Recipes_RecipeId",
                table: "UserRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRecipes_AspNetUsers_UserId",
                table: "UserRecipes");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRecipes",
                table: "UserRecipes");

            migrationBuilder.RenameTable(
                name: "UserRecipes",
                newName: "UserRecipe");

            migrationBuilder.RenameIndex(
                name: "IX_UserRecipes_UserId",
                table: "UserRecipe",
                newName: "IX_UserRecipe_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRecipes_RecipeId",
                table: "UserRecipe",
                newName: "IX_UserRecipe_RecipeId");

            migrationBuilder.RenameIndex(
                name: "IX_UserRecipes_IsDeleted",
                table: "UserRecipe",
                newName: "IX_UserRecipe_IsDeleted");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "CookingVessels",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRecipe",
                table: "UserRecipe",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipe_Recipes_RecipeId",
                table: "UserRecipe",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserRecipe_AspNetUsers_UserId",
                table: "UserRecipe",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

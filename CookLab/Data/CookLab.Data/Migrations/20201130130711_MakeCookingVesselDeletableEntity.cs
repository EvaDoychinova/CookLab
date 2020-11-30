using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookLab.Data.Migrations
{
    public partial class MakeCookingVesselDeletableEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "CookingVessels",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CookingVessels",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_CookingVessels_IsDeleted",
                table: "CookingVessels",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CookingVessels_IsDeleted",
                table: "CookingVessels");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "CookingVessels");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CookingVessels");
        }
    }
}

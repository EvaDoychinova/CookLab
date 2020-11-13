using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CookLab.Data.Migrations
{
    public partial class ChangeCookingVesselEntityAndAddRequiredConstraintsToEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VesselDimensions");

            migrationBuilder.AddColumn<double>(
                name: "Diameter",
                table: "CookingVessels",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Height",
                table: "CookingVessels",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CookingVessels",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "SideA",
                table: "CookingVessels",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SideB",
                table: "CookingVessels",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedOn",
                table: "CategoryRecipes",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "CategoryRecipes",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_CategoryRecipes_IsDeleted",
                table: "CategoryRecipes",
                column: "IsDeleted");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryRecipes_IsDeleted",
                table: "CategoryRecipes");

            migrationBuilder.DropColumn(
                name: "Diameter",
                table: "CookingVessels");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "CookingVessels");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CookingVessels");

            migrationBuilder.DropColumn(
                name: "SideA",
                table: "CookingVessels");

            migrationBuilder.DropColumn(
                name: "SideB",
                table: "CookingVessels");

            migrationBuilder.DropColumn(
                name: "DeletedOn",
                table: "CategoryRecipes");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "CategoryRecipes");

            migrationBuilder.CreateTable(
                name: "VesselDimensions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CookingVesselId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Diameter = table.Column<double>(type: "float", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SideA = table.Column<double>(type: "float", nullable: false),
                    SideB = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VesselDimensions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VesselDimensions_CookingVessels_CookingVesselId",
                        column: x => x.CookingVesselId,
                        principalTable: "CookingVessels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VesselDimensions_CookingVesselId",
                table: "VesselDimensions",
                column: "CookingVesselId",
                unique: true);
        }
    }
}

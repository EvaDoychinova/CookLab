namespace CookLab.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class ChangeFormDimensionEntityNameToVesselDimension : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookingVessels_FormDimensions_FormDimensionId",
                table: "CookingVessels");

            migrationBuilder.DropIndex(
                name: "IX_CookingVessels_FormDimensionId",
                table: "CookingVessels");

            migrationBuilder.DropColumn(
                name: "FormDimensionId",
                table: "CookingVessels");

            migrationBuilder.AddColumn<int>(
                name: "VesselDimensionId",
                table: "CookingVessels",
                nullable: false,
                defaultValue: 0);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CookingVessels_FormDimensions_VesselDimensionId",
                table: "CookingVessels");

            migrationBuilder.DropIndex(
                name: "IX_CookingVessels_VesselDimensionId",
                table: "CookingVessels");

            migrationBuilder.DropColumn(
                name: "VesselDimensionId",
                table: "CookingVessels");

            migrationBuilder.AddColumn<int>(
                name: "FormDimensionId",
                table: "CookingVessels",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_CookingVessels_FormDimensionId",
                table: "CookingVessels",
                column: "FormDimensionId");

            migrationBuilder.AddForeignKey(
                name: "FK_CookingVessels_FormDimensions_FormDimensionId",
                table: "CookingVessels",
                column: "FormDimensionId",
                principalTable: "FormDimensions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

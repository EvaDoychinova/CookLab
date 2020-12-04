using Microsoft.EntityFrameworkCore.Migrations;

namespace CookLab.Data.Migrations
{
    public partial class RemoveIpAddressColumnFromContactForm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Contacts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Contacts",
                type: "nvarchar(39)",
                maxLength: 39,
                nullable: false,
                defaultValue: "");
        }
    }
}

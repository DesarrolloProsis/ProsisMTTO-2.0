using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class MitraCarrilesDTC3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumCapufe",
                table: "ReplacementCatalogs");

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "ReplacementCatalogs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "ReplacementCatalogs");

            migrationBuilder.AddColumn<string>(
                name: "NumCapufe",
                table: "ReplacementCatalogs",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true);
        }
    }
}

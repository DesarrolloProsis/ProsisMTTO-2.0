using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class MitraCarrilesDTC1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DTCTechnical_DTCHeaderId",
                table: "DTCTechnical");

            migrationBuilder.DropColumn(
                name: "IdGare",
                table: "DTCTechnical");

            migrationBuilder.DropColumn(
                name: "LanesCatalogId",
                table: "DTCTechnical");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Components");

            migrationBuilder.AddColumn<string>(
                name: "Model",
                table: "Components",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnical_DTCHeaderId",
                table: "DTCTechnical",
                column: "DTCHeaderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DTCTechnical_DTCHeaderId",
                table: "DTCTechnical");

            migrationBuilder.DropColumn(
                name: "Model",
                table: "Components");

            migrationBuilder.AddColumn<string>(
                name: "IdGare",
                table: "DTCTechnical",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LanesCatalogId",
                table: "DTCTechnical",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Components",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnical_DTCHeaderId",
                table: "DTCTechnical",
                column: "DTCHeaderId",
                unique: true);
        }
    }
}

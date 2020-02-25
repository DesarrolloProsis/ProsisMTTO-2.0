using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class MitraCarrilesDTC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DTCTechnical_LanesCatalogs_LanesCatalogId_IdGare",
                table: "DTCTechnical");

            migrationBuilder.DropIndex(
                name: "IX_DTCTechnical_LanesCatalogId",
                table: "DTCTechnical");

            migrationBuilder.DropIndex(
                name: "IX_DTCTechnical_LanesCatalogId_IdGare",
                table: "DTCTechnical");

            migrationBuilder.AddColumn<string>(
                name: "LanesCatalogCapufeLaneNum",
                table: "DTCTechnical",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LanesCatalogIdGare",
                table: "DTCTechnical",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Modelo",
                table: "Components",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnical_LanesCatalogCapufeLaneNum_LanesCatalogIdGare",
                table: "DTCTechnical",
                columns: new[] { "LanesCatalogCapufeLaneNum", "LanesCatalogIdGare" });

            migrationBuilder.AddForeignKey(
                name: "FK_DTCTechnical_LanesCatalogs_LanesCatalogCapufeLaneNum_LanesCatalogIdGare",
                table: "DTCTechnical",
                columns: new[] { "LanesCatalogCapufeLaneNum", "LanesCatalogIdGare" },
                principalTable: "LanesCatalogs",
                principalColumns: new[] { "CapufeLaneNum", "IdGare" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DTCTechnical_LanesCatalogs_LanesCatalogCapufeLaneNum_LanesCatalogIdGare",
                table: "DTCTechnical");

            migrationBuilder.DropIndex(
                name: "IX_DTCTechnical_LanesCatalogCapufeLaneNum_LanesCatalogIdGare",
                table: "DTCTechnical");

            migrationBuilder.DropColumn(
                name: "LanesCatalogCapufeLaneNum",
                table: "DTCTechnical");

            migrationBuilder.DropColumn(
                name: "LanesCatalogIdGare",
                table: "DTCTechnical");

            migrationBuilder.DropColumn(
                name: "Modelo",
                table: "Components");

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnical_LanesCatalogId",
                table: "DTCTechnical",
                column: "LanesCatalogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnical_LanesCatalogId_IdGare",
                table: "DTCTechnical",
                columns: new[] { "LanesCatalogId", "IdGare" });

            migrationBuilder.AddForeignKey(
                name: "FK_DTCTechnical_LanesCatalogs_LanesCatalogId_IdGare",
                table: "DTCTechnical",
                columns: new[] { "LanesCatalogId", "IdGare" },
                principalTable: "LanesCatalogs",
                principalColumns: new[] { "CapufeLaneNum", "IdGare" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class compuesta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DTCTechnical_LanesCatalogs_LanesCatalogId",
                table: "DTCTechnical");

            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_CapufeLaneNum",
                table: "LanesCatalogs");

            migrationBuilder.AddColumn<string>(
                name: "IdGare",
                table: "LanesCatalogs",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IdGare",
                table: "DTCTechnical",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_CapufeLaneNum",
                table: "LanesCatalogs",
                columns: new[] { "CapufeLaneNum", "IdGare" });

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnical_LanesCatalogId_IdGare",
                table: "DTCTechnical",
                columns: new[] { "LanesCatalogId", "IdGare" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DTCTechnical_LanesCatalogs_LanesCatalogId_IdGare",
                table: "DTCTechnical",
                columns: new[] { "LanesCatalogId", "IdGare" },
                principalTable: "LanesCatalogs",
                principalColumns: new[] { "CapufeLaneNum", "IdGare" },
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DTCTechnical_LanesCatalogs_LanesCatalogId_IdGare",
                table: "DTCTechnical");

            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_CapufeLaneNum",
                table: "LanesCatalogs");

            migrationBuilder.DropIndex(
                name: "IX_DTCTechnical_LanesCatalogId_IdGare",
                table: "DTCTechnical");

            migrationBuilder.DropColumn(
                name: "IdGare",
                table: "LanesCatalogs");

            migrationBuilder.DropColumn(
                name: "IdGare",
                table: "DTCTechnical");

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_CapufeLaneNum",
                table: "LanesCatalogs",
                column: "CapufeLaneNum");

            migrationBuilder.AddForeignKey(
                name: "FK_DTCTechnical_LanesCatalogs_LanesCatalogId",
                table: "DTCTechnical",
                column: "LanesCatalogId",
                principalTable: "LanesCatalogs",
                principalColumn: "CapufeLaneNum",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

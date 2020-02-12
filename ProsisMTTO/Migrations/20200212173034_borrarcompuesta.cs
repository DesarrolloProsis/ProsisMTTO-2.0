using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class borrarcompuesta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "IdGare",
                table: "DTCTechnical",
                type: "nvarchar(3)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "IdGare",
                table: "DTCTechnical",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(3)");

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
    }
}

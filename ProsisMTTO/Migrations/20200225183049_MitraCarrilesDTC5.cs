using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class MitraCarrilesDTC5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_ReplacementCatalogs_ReplacementCatalogId",
                table: "Components");

            migrationBuilder.DropIndex(
                name: "IX_Components_ReplacementCatalogId",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "ReplacementCatalogId",
                table: "Components");

            migrationBuilder.AddColumn<int>(
                name: "ComponentId",
                table: "ReplacementCatalogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementCatalogs_ComponentId",
                table: "ReplacementCatalogs",
                column: "ComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReplacementCatalogs_Components_ComponentId",
                table: "ReplacementCatalogs",
                column: "ComponentId",
                principalTable: "Components",
                principalColumn: "ComponentId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReplacementCatalogs_Components_ComponentId",
                table: "ReplacementCatalogs");

            migrationBuilder.DropIndex(
                name: "IX_ReplacementCatalogs_ComponentId",
                table: "ReplacementCatalogs");

            migrationBuilder.DropColumn(
                name: "ComponentId",
                table: "ReplacementCatalogs");

            migrationBuilder.AddColumn<int>(
                name: "ReplacementCatalogId",
                table: "Components",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Components_ReplacementCatalogId",
                table: "Components",
                column: "ReplacementCatalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_ReplacementCatalogs_ReplacementCatalogId",
                table: "Components",
                column: "ReplacementCatalogId",
                principalTable: "ReplacementCatalogs",
                principalColumn: "ReplacementCatalogId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

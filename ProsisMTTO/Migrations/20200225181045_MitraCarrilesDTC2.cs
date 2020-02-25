using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class MitraCarrilesDTC2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Components",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ReplacementCatalogId",
                table: "Components",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ReplacementCatalogs",
                columns: table => new
                {
                    ReplacementCatalogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NumCapufe = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplacementCatalogs", x => x.ReplacementCatalogId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_ReplacementCatalogs_ReplacementCatalogId",
                table: "Components");

            migrationBuilder.DropTable(
                name: "ReplacementCatalogs");

            migrationBuilder.DropIndex(
                name: "IX_Components_ReplacementCatalogId",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "ReplacementCatalogId",
                table: "Components");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Components",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);
        }
    }
}

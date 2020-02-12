using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class typeCarril : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeCarrilId",
                table: "LanesCatalogs",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TypeCarrils",
                columns: table => new
                {
                    TypeCarrilId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    LanesCatalog = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCarrils", x => x.TypeCarrilId);
                });

            migrationBuilder.InsertData(
                table: "TypeCarrils",
                columns: new[] { "TypeCarrilId", "LanesCatalog", "Name" },
                values: new object[] { 1, null, "Express" });

            migrationBuilder.InsertData(
                table: "TypeCarrils",
                columns: new[] { "TypeCarrilId", "LanesCatalog", "Name" },
                values: new object[] { 2, null, "Multimodal" });

            migrationBuilder.CreateIndex(
                name: "IX_LanesCatalogs_TypeCarrilId",
                table: "LanesCatalogs",
                column: "TypeCarrilId");

            migrationBuilder.AddForeignKey(
                name: "FK_LanesCatalogs_TypeCarrils_TypeCarrilId",
                table: "LanesCatalogs",
                column: "TypeCarrilId",
                principalTable: "TypeCarrils",
                principalColumn: "TypeCarrilId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanesCatalogs_TypeCarrils_TypeCarrilId",
                table: "LanesCatalogs");

            migrationBuilder.DropTable(
                name: "TypeCarrils");

            migrationBuilder.DropIndex(
                name: "IX_LanesCatalogs_TypeCarrilId",
                table: "LanesCatalogs");

            migrationBuilder.DropColumn(
                name: "TypeCarrilId",
                table: "LanesCatalogs");
        }
    }
}

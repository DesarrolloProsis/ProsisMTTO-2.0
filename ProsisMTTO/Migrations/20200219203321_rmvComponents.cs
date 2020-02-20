using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class rmvComponents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DTCInventories_Inventory_InventoryId",
                table: "DTCInventories");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Components_ComponentId",
                table: "Inventory");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropIndex(
                name: "IX_Inventory_ComponentId",
                table: "Inventory");

            migrationBuilder.DropIndex(
                name: "IX_DTCInventories_InventoryId",
                table: "DTCInventories");

            migrationBuilder.DropColumn(
                name: "Brand",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "TypeService",
                table: "Inventory");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Brand",
                table: "Inventory",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Inventory",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<string>(
                name: "TypeService",
                table: "Inventory",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    ComponentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.ComponentId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ComponentId",
                table: "Inventory",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_DTCInventories_InventoryId",
                table: "DTCInventories",
                column: "InventoryId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DTCInventories_Inventory_InventoryId",
                table: "DTCInventories",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Components_ComponentId",
                table: "Inventory",
                column: "ComponentId",
                principalTable: "Components",
                principalColumn: "ComponentId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class addComponentsInventoryChngd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    ComponentId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Year = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ServiceType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.ComponentId);
                });

            migrationBuilder.CreateTable(
                name: "Inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumPart = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    PieceYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    InventoryImage = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    ComponentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inventory_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "ComponentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DTCInventories_InventoryId",
                table: "DTCInventories",
                column: "InventoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ComponentId",
                table: "Inventory",
                column: "ComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_DTCInventories_Inventory_InventoryId",
                table: "DTCInventories",
                column: "InventoryId",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DTCInventories_Inventory_InventoryId",
                table: "DTCInventories");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropIndex(
                name: "IX_DTCInventories_InventoryId",
                table: "DTCInventories");
        }
    }
}

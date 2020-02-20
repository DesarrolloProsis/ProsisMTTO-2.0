using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class UnitTypeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitTypeId",
                table: "Components",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Units",
                columns: table => new
                {
                    UnitTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Units", x => x.UnitTypeId);
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitTypeId", "Name" },
                values: new object[] { 1, "Pza" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitTypeId", "Name" },
                values: new object[] { 2, "Metro" });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitTypeId", "Name" },
                values: new object[] { 3, "Mano de Obra" });

            migrationBuilder.CreateIndex(
                name: "IX_Components_UnitTypeId",
                table: "Components",
                column: "UnitTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Units_UnitTypeId",
                table: "Components",
                column: "UnitTypeId",
                principalTable: "Units",
                principalColumn: "UnitTypeId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Units_UnitTypeId",
                table: "Components");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropIndex(
                name: "IX_Components_UnitTypeId",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "UnitTypeId",
                table: "Components");
        }
    }
}

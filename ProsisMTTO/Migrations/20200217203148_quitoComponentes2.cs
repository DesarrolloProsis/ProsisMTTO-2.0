using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class quitoComponentes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Components");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    ComponentName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PieceYear = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: true),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Year = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ComponentName", x => x.ComponentName);
                });
        }
    }
}

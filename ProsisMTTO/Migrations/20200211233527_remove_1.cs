using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class remove_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LaneType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LaneType",
                columns: table => new
                {
                    LaneTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LaneTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaneType", x => x.LaneTypeId);
                });

            migrationBuilder.InsertData(
                table: "LaneType",
                columns: new[] { "LaneTypeId", "LaneTypeName" },
                values: new object[] { 1, "Express" });

            migrationBuilder.InsertData(
                table: "LaneType",
                columns: new[] { "LaneTypeId", "LaneTypeName" },
                values: new object[] { 2, "Multimodal" });
        }
    }
}

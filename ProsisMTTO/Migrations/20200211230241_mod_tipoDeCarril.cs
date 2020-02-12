using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class mod_tipoDeCarril : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LaneTypeName",
                table: "LaneTypes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "LaneTypes",
                columns: new[] { "LaneTypeId", "LaneTypeName" },
                values: new object[] { 1, "Express" });

            migrationBuilder.InsertData(
                table: "LaneTypes",
                columns: new[] { "LaneTypeId", "LaneTypeName" },
                values: new object[] { 2, "Multimodal" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "LaneTypes",
                keyColumn: "LaneTypeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "LaneTypes",
                keyColumn: "LaneTypeId",
                keyValue: 2);

            migrationBuilder.AlterColumn<int>(
                name: "LaneTypeName",
                table: "LaneTypes",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}

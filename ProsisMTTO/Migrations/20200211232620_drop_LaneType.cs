using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class drop_LaneType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LaneTypes",
                table: "LaneTypes");

            migrationBuilder.RenameTable(
                name: "LaneTypes",
                newName: "LaneType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LaneType",
                table: "LaneType",
                column: "LaneTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_LaneType",
                table: "LaneType");

            migrationBuilder.RenameTable(
                name: "LaneType",
                newName: "LaneTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LaneTypes",
                table: "LaneTypes",
                column: "LaneTypeId");
        }
    }
}

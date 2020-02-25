using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class MitraCarrilesDTC6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DTCServices_ComponentId",
                table: "DTCServices");

            migrationBuilder.RenameColumn(
                name: "DateRecord",
                table: "DTCInventories",
                newName: "DateRecordRequest");

            migrationBuilder.AddColumn<bool>(
                name: "Authorization",
                table: "DTCInventories",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "DTCInventories",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "AutomaticSignature",
                table: "Components",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "IX_DTCServices_ComponentId",
                table: "DTCServices",
                column: "ComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DTCServices_ComponentId",
                table: "DTCServices");

            migrationBuilder.DropColumn(
                name: "Authorization",
                table: "DTCInventories");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "DTCInventories");

            migrationBuilder.DropColumn(
                name: "AutomaticSignature",
                table: "Components");

            migrationBuilder.RenameColumn(
                name: "DateRecordRequest",
                table: "DTCInventories",
                newName: "DateRecord");

            migrationBuilder.CreateIndex(
                name: "IX_DTCServices_ComponentId",
                table: "DTCServices",
                column: "ComponentId",
                unique: true);
        }
    }
}

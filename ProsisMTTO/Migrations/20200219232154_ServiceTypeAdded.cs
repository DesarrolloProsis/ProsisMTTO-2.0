using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class ServiceTypeAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceType",
                table: "Components");

            migrationBuilder.AddColumn<int>(
                name: "ServiceTypeId",
                table: "Components",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ServiceTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceTypeId);
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "Name" },
                values: new object[] { 1, "Servicio" });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "Name" },
                values: new object[] { 2, "Refaccion" });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "Name" },
                values: new object[] { 3, "Componente" });

            migrationBuilder.CreateIndex(
                name: "IX_Components_ServiceTypeId",
                table: "Components",
                column: "ServiceTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_ServiceTypes_ServiceTypeId",
                table: "Components",
                column: "ServiceTypeId",
                principalTable: "ServiceTypes",
                principalColumn: "ServiceTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_ServiceTypes_ServiceTypeId",
                table: "Components");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropIndex(
                name: "IX_Components_ServiceTypeId",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "ServiceTypeId",
                table: "Components");

            migrationBuilder.AddColumn<int>(
                name: "ServiceType",
                table: "Components",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

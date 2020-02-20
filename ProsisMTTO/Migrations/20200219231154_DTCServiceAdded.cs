using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class DTCServiceAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DTCServices",
                columns: table => new
                {
                    DTCTechnicalId = table.Column<string>(nullable: false),
                    ComponentId = table.Column<int>(nullable: false),
                    DateRecord = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTCServices", x => new { x.DTCTechnicalId, x.ComponentId });
                    table.ForeignKey(
                        name: "FK_DTCServices_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "ComponentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DTCServices_DTCTechnical_DTCTechnicalId",
                        column: x => x.DTCTechnicalId,
                        principalTable: "DTCTechnical",
                        principalColumn: "ReferenceNum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DTCServices_ComponentId",
                table: "DTCServices",
                column: "ComponentId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DTCServices");
        }
    }
}

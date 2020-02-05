using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DTCHeaders",
                columns: table => new
                {
                    DTCHeaderId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    AgreementNum = table.Column<int>(type: "int", nullable: false),
                    ManagerName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_DTCHeaderId", x => x.DTCHeaderId);
                });

            migrationBuilder.CreateTable(
                name: "SquaresCatalogs",
                columns: table => new
                {
                    SquareNum = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    SquareName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Delegation = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_SquareNum", x => x.SquareNum);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_UserId", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "LanesCatalogs",
                columns: table => new
                {
                    CapufeLaneNum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Lane = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    LaneType = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    SquaresCatalogId = table.Column<int>(type: "int", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CapufeLaneNum", x => x.CapufeLaneNum);
                    table.ForeignKey(
                        name: "FK_LanesCatalogs_SquaresCatalogs_SquaresCatalogId",
                        column: x => x.SquaresCatalogId,
                        principalTable: "SquaresCatalogs",
                        principalColumn: "SquareNum",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DTCTechnical",
                columns: table => new
                {
                    ReferenceNum = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    LanesCatalogId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DTCHeaderId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AxaNum = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    FailureNum = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FailureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ElaborationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpinionType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Diagnostic = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_ReferenceNum", x => x.ReferenceNum);
                    table.ForeignKey(
                        name: "FK_DTCTechnical_DTCHeaders_DTCHeaderId",
                        column: x => x.DTCHeaderId,
                        principalTable: "DTCHeaders",
                        principalColumn: "DTCHeaderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DTCTechnical_LanesCatalogs_LanesCatalogId",
                        column: x => x.LanesCatalogId,
                        principalTable: "LanesCatalogs",
                        principalColumn: "CapufeLaneNum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DTCTechnical_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DTCMovements",
                columns: table => new
                {
                    MovementId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DTCTechnicalId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_MovementId", x => x.MovementId);
                    table.ForeignKey(
                        name: "FK_DTCMovements_DTCTechnical_DTCTechnicalId",
                        column: x => x.DTCTechnicalId,
                        principalTable: "DTCTechnical",
                        principalColumn: "ReferenceNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SparePartsCatalogs",
                columns: table => new
                {
                    NumPart = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeService = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    Unit = table.Column<int>(type: "int", nullable: false),
                    PieceYear = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    SparePartImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DTCTechnicalReferenceNum = table.Column<string>(type: "nvarchar(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_NumPart", x => x.NumPart);
                    table.ForeignKey(
                        name: "FK_SparePartsCatalogs_DTCTechnical_DTCTechnicalReferenceNum",
                        column: x => x.DTCTechnicalReferenceNum,
                        principalTable: "DTCTechnical",
                        principalColumn: "ReferenceNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DTCMovements_DTCTechnicalId",
                table: "DTCMovements",
                column: "DTCTechnicalId");

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnical_DTCHeaderId",
                table: "DTCTechnical",
                column: "DTCHeaderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnical_LanesCatalogId",
                table: "DTCTechnical",
                column: "LanesCatalogId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnical_UserId",
                table: "DTCTechnical",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LanesCatalogs_SquaresCatalogId",
                table: "LanesCatalogs",
                column: "SquaresCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_SparePartsCatalogs_DTCTechnicalReferenceNum",
                table: "SparePartsCatalogs",
                column: "DTCTechnicalReferenceNum");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DTCMovements");

            migrationBuilder.DropTable(
                name: "SparePartsCatalogs");

            migrationBuilder.DropTable(
                name: "DTCTechnical");

            migrationBuilder.DropTable(
                name: "DTCHeaders");

            migrationBuilder.DropTable(
                name: "LanesCatalogs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "SquaresCatalogs");
        }
    }
}

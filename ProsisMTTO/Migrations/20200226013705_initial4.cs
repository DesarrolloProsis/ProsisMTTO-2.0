using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class initial4 : Migration
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
                    Position = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_DTCHeaderId", x => x.DTCHeaderId);
                });

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
                name: "TypeCarrils",
                columns: table => new
                {
                    TypeCarrilId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeCarrils", x => x.TypeCarrilId);
                });

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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_UserId", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AdminSquares",
                columns: table => new
                {
                    AdminId = table.Column<string>(nullable: false),
                    SquaresCatalogId = table.Column<string>(nullable: true),
                    NumCapufe = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NumGea = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    NomOperador = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdminSquares", x => x.AdminId);
                    table.ForeignKey(
                        name: "FK_AdminSquares_SquaresCatalogs_SquaresCatalogId",
                        column: x => x.SquaresCatalogId,
                        principalTable: "SquaresCatalogs",
                        principalColumn: "SquareNum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LanesCatalogs",
                columns: table => new
                {
                    CapufeLaneNum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    IdGare = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    Lane = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    LaneType = table.Column<int>(type: "int", maxLength: 15, nullable: false),
                    SquaresCatalogId = table.Column<string>(type: "nvarchar(10)", nullable: false),
                    TypeCarrilId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_CapufeLaneNum", x => new { x.CapufeLaneNum, x.IdGare });
                    table.ForeignKey(
                        name: "FK_LanesCatalogs_SquaresCatalogs_SquaresCatalogId",
                        column: x => x.SquaresCatalogId,
                        principalTable: "SquaresCatalogs",
                        principalColumn: "SquareNum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LanesCatalogs_TypeCarrils_TypeCarrilId",
                        column: x => x.TypeCarrilId,
                        principalTable: "TypeCarrils",
                        principalColumn: "TypeCarrilId",
                        onDelete: ReferentialAction.Restrict);
                });

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
                    UnitId = table.Column<int>(nullable: false),
                    ServiceTypeId = table.Column<int>(nullable: false),
                    Model = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    AutomaticSignature = table.Column<bool>(nullable: false),
                    DTCHeaderId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.ComponentId);
                    table.ForeignKey(
                        name: "FK_Components_DTCHeaders_DTCHeaderId",
                        column: x => x.DTCHeaderId,
                        principalTable: "DTCHeaders",
                        principalColumn: "DTCHeaderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Components_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Components_Units_UnitId",
                        column: x => x.UnitId,
                        principalTable: "Units",
                        principalColumn: "UnitTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DTCTechnical",
                columns: table => new
                {
                    ReferenceNum = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    DTCHeaderId = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    AxaNum = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: true),
                    FailureNum = table.Column<int>(nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    FailureDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IncidentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ElaborationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ShippingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OpinionType = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Diagnostic = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Observation = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    Image = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LanesCatalogCapufeLaneNum = table.Column<string>(nullable: true),
                    LanesCatalogIdGare = table.Column<string>(nullable: true)
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
                        name: "FK_DTCTechnical_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DTCTechnical_LanesCatalogs_LanesCatalogCapufeLaneNum_LanesCatalogIdGare",
                        columns: x => new { x.LanesCatalogCapufeLaneNum, x.LanesCatalogIdGare },
                        principalTable: "LanesCatalogs",
                        principalColumns: new[] { "CapufeLaneNum", "IdGare" },
                        onDelete: ReferentialAction.Restrict);
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

            migrationBuilder.CreateTable(
                name: "ReplacementCatalogs",
                columns: table => new
                {
                    ReplacementCatalogId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Model = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    ComponentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReplacementCatalogs", x => x.ReplacementCatalogId);
                    table.ForeignKey(
                        name: "FK_ReplacementCatalogs_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "ComponentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DTCMovements",
                columns: table => new
                {
                    MovementId = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DTCTechnicalId = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    ModificationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true)
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

            migrationBuilder.CreateTable(
                name: "DTCInventories",
                columns: table => new
                {
                    DTCTechnicalId = table.Column<string>(nullable: false),
                    InventoryId = table.Column<int>(nullable: false),
                    DateRecordRequest = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Authorization = table.Column<bool>(nullable: false),
                    Location = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTCInventories", x => new { x.DTCTechnicalId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_DTCInventories_DTCTechnical_DTCTechnicalId",
                        column: x => x.DTCTechnicalId,
                        principalTable: "DTCTechnical",
                        principalColumn: "ReferenceNum",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DTCInventories_Inventory_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Servicio" },
                    { 2, "Refaccion" },
                    { 3, "Componente" }
                });

            migrationBuilder.InsertData(
                table: "TypeCarrils",
                columns: new[] { "TypeCarrilId", "Name" },
                values: new object[,]
                {
                    { 1, "Express" },
                    { 2, "Multimodal" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "UnitTypeId", "Name" },
                values: new object[,]
                {
                    { 1, "Pza" },
                    { 2, "Metro" },
                    { 3, "Mano de Obra" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdminSquares_SquaresCatalogId",
                table: "AdminSquares",
                column: "SquaresCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_DTCHeaderId",
                table: "Components",
                column: "DTCHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_ServiceTypeId",
                table: "Components",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Components_UnitId",
                table: "Components",
                column: "UnitId");

            migrationBuilder.CreateIndex(
                name: "IX_DTCInventories_InventoryId",
                table: "DTCInventories",
                column: "InventoryId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DTCMovements_DTCTechnicalId",
                table: "DTCMovements",
                column: "DTCTechnicalId");

            migrationBuilder.CreateIndex(
                name: "IX_DTCServices_ComponentId",
                table: "DTCServices",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnical_DTCHeaderId",
                table: "DTCTechnical",
                column: "DTCHeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnical_UserId",
                table: "DTCTechnical",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_DTCTechnical_LanesCatalogCapufeLaneNum_LanesCatalogIdGare",
                table: "DTCTechnical",
                columns: new[] { "LanesCatalogCapufeLaneNum", "LanesCatalogIdGare" });

            migrationBuilder.CreateIndex(
                name: "IX_Inventory_ComponentId",
                table: "Inventory",
                column: "ComponentId");

            migrationBuilder.CreateIndex(
                name: "IX_LanesCatalogs_SquaresCatalogId",
                table: "LanesCatalogs",
                column: "SquaresCatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_LanesCatalogs_TypeCarrilId",
                table: "LanesCatalogs",
                column: "TypeCarrilId");

            migrationBuilder.CreateIndex(
                name: "IX_ReplacementCatalogs_ComponentId",
                table: "ReplacementCatalogs",
                column: "ComponentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdminSquares");

            migrationBuilder.DropTable(
                name: "DTCInventories");

            migrationBuilder.DropTable(
                name: "DTCMovements");

            migrationBuilder.DropTable(
                name: "DTCServices");

            migrationBuilder.DropTable(
                name: "ReplacementCatalogs");

            migrationBuilder.DropTable(
                name: "Inventory");

            migrationBuilder.DropTable(
                name: "DTCTechnical");

            migrationBuilder.DropTable(
                name: "Components");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "LanesCatalogs");

            migrationBuilder.DropTable(
                name: "DTCHeaders");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "Units");

            migrationBuilder.DropTable(
                name: "SquaresCatalogs");

            migrationBuilder.DropTable(
                name: "TypeCarrils");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class Cambios2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SparePartsCatalogs_DTCTechnical_DTCTechnicalReferenceNum",
                table: "SparePartsCatalogs");

            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_NumPart",
                table: "SparePartsCatalogs");

            migrationBuilder.AlterColumn<string>(
                name: "TypeService",
                table: "SparePartsCatalogs",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "PieceYear",
                table: "SparePartsCatalogs",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "SparePartsCatalogs",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AlterColumn<string>(
                name: "NumPart",
                table: "SparePartsCatalogs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "SparePartsCatalogs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "PieceYear",
                table: "Components",
                type: "nvarchar(4)",
                maxLength: 4,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_Id",
                table: "SparePartsCatalogs",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DTCInventories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateRecord = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DTCInventories", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DTCInventories");

            migrationBuilder.DropPrimaryKey(
                name: "PrimaryKey_Id",
                table: "SparePartsCatalogs");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "SparePartsCatalogs");

            migrationBuilder.DropColumn(
                name: "PieceYear",
                table: "Components");

            migrationBuilder.AlterColumn<string>(
                name: "TypeService",
                table: "SparePartsCatalogs",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PieceYear",
                table: "SparePartsCatalogs",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(5)",
                oldMaxLength: 5,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NumPart",
                table: "SparePartsCatalogs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Brand",
                table: "SparePartsCatalogs",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PrimaryKey_NumPart",
                table: "SparePartsCatalogs",
                column: "NumPart");

            migrationBuilder.AddForeignKey(
                name: "FK_SparePartsCatalogs_DTCTechnical_DTCTechnicalReferenceNum",
                table: "SparePartsCatalogs",
                column: "DTCTechnicalReferenceNum",
                principalTable: "DTCTechnical",
                principalColumn: "ReferenceNum",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

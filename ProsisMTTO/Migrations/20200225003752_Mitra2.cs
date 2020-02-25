using Microsoft.EntityFrameworkCore.Migrations;

namespace ProsisMTTO.Migrations
{
    public partial class Mitra2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SquaresCatalogs_AdminSquares_AdminSquareAdminId",
                table: "SquaresCatalogs");

            migrationBuilder.DropIndex(
                name: "IX_SquaresCatalogs_AdminSquareAdminId",
                table: "SquaresCatalogs");

            migrationBuilder.DropColumn(
                name: "AdminSquareAdminId",
                table: "SquaresCatalogs");

            migrationBuilder.AlterColumn<string>(
                name: "SquaresCatalogId",
                table: "AdminSquares",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdminSquares_SquaresCatalogId",
                table: "AdminSquares",
                column: "SquaresCatalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_AdminSquares_SquaresCatalogs_SquaresCatalogId",
                table: "AdminSquares",
                column: "SquaresCatalogId",
                principalTable: "SquaresCatalogs",
                principalColumn: "SquareNum",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdminSquares_SquaresCatalogs_SquaresCatalogId",
                table: "AdminSquares");

            migrationBuilder.DropIndex(
                name: "IX_AdminSquares_SquaresCatalogId",
                table: "AdminSquares");

            migrationBuilder.AddColumn<string>(
                name: "AdminSquareAdminId",
                table: "SquaresCatalogs",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SquaresCatalogId",
                table: "AdminSquares",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SquaresCatalogs_AdminSquareAdminId",
                table: "SquaresCatalogs",
                column: "AdminSquareAdminId");

            migrationBuilder.AddForeignKey(
                name: "FK_SquaresCatalogs_AdminSquares_AdminSquareAdminId",
                table: "SquaresCatalogs",
                column: "AdminSquareAdminId",
                principalTable: "AdminSquares",
                principalColumn: "AdminId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

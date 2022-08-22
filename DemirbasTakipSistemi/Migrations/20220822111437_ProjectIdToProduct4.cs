using Microsoft.EntityFrameworkCore.Migrations;

namespace DemirbasTakipSistemi.Migrations
{
    public partial class ProjectIdToProduct4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Projects_ProjectId",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Product",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "ProjectIdGet",
                table: "Product",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Projects_ProjectId",
                table: "Product",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Projects_ProjectId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProjectIdGet",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Product",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Projects_ProjectId",
                table: "Product",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

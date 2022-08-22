using Microsoft.EntityFrameworkCore.Migrations;

namespace DemirbasTakipSistemi.Migrations
{
    public partial class ProjectIdToProduct : Migration
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
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectName",
                table: "Product",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Projects_ProjectId",
                table: "Product",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Projects_ProjectId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProjectName",
                table: "Product");

            migrationBuilder.AlterColumn<int>(
                name: "ProjectId",
                table: "Product",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Projects_ProjectId",
                table: "Product",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

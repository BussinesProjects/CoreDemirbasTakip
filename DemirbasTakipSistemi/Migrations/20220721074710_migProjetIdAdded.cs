using Microsoft.EntityFrameworkCore.Migrations;

namespace DemirbasTakipSistemi.Migrations
{
    public partial class migProjetIdAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Projects_ProjectCode1",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProjectCode1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProjectCode1",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectCode",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Projects",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProjectId",
                table: "Product",
                column: "ProjectId");

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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProjectId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Product");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectCode",
                table: "Projects",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectCode1",
                table: "Product",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "ProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProjectCode1",
                table: "Product",
                column: "ProjectCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Projects_ProjectCode1",
                table: "Product",
                column: "ProjectCode1",
                principalTable: "Projects",
                principalColumn: "ProjectCode",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DemirbasTakipSistemi.Migrations
{
    public partial class keyValueFix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectProducts_Projects_ProjectisEnabled",
                table: "ProjectProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectProducts",
                table: "ProjectProducts");

            migrationBuilder.DropIndex(
                name: "IX_ProjectProducts_ProjectisEnabled",
                table: "ProjectProducts");

            migrationBuilder.DropColumn(
                name: "ProjectisEnabled",
                table: "ProjectProducts");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectCode",
                table: "Projects",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectCode",
                table: "ProjectProducts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectCode1",
                table: "ProjectProducts",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "ProjectCode");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectProducts",
                table: "ProjectProducts",
                column: "ProjectCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProducts_ProjectCode1",
                table: "ProjectProducts",
                column: "ProjectCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectProducts_Projects_ProjectCode1",
                table: "ProjectProducts",
                column: "ProjectCode1",
                principalTable: "Projects",
                principalColumn: "ProjectCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProjectProducts_Projects_ProjectCode1",
                table: "ProjectProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Projects",
                table: "Projects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectProducts",
                table: "ProjectProducts");

            migrationBuilder.DropIndex(
                name: "IX_ProjectProducts_ProjectCode1",
                table: "ProjectProducts");

            migrationBuilder.DropColumn(
                name: "ProjectCode1",
                table: "ProjectProducts");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectCode",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProjectCode",
                table: "ProjectProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<bool>(
                name: "ProjectisEnabled",
                table: "ProjectProducts",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Projects",
                table: "Projects",
                column: "isEnabled");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectProducts",
                table: "ProjectProducts",
                column: "isEnabled");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProducts_ProjectisEnabled",
                table: "ProjectProducts",
                column: "ProjectisEnabled");

            migrationBuilder.AddForeignKey(
                name: "FK_ProjectProducts_Projects_ProjectisEnabled",
                table: "ProjectProducts",
                column: "ProjectisEnabled",
                principalTable: "Projects",
                principalColumn: "isEnabled",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

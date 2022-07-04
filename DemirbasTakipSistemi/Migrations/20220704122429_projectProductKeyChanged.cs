using Microsoft.EntityFrameworkCore.Migrations;

namespace DemirbasTakipSistemi.Migrations
{
    public partial class projectProductKeyChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectProducts",
                table: "ProjectProducts");

            migrationBuilder.AlterColumn<string>(
                name: "ProductSerialNumber",
                table: "ProjectProducts",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProjectCode",
                table: "ProjectProducts",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectProducts",
                table: "ProjectProducts",
                column: "ProductSerialNumber");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProjectProducts",
                table: "ProjectProducts");

            migrationBuilder.AlterColumn<string>(
                name: "ProjectCode",
                table: "ProjectProducts",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ProductSerialNumber",
                table: "ProjectProducts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProjectProducts",
                table: "ProjectProducts",
                column: "ProjectCode");
        }
    }
}

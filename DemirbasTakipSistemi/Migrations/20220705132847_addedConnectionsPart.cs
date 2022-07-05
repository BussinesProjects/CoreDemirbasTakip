using Microsoft.EntityFrameworkCore.Migrations;

namespace DemirbasTakipSistemi.Migrations
{
    public partial class addedConnectionsPart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Connections",
                table: "Projects",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Connections",
                table: "Projects");
        }
    }
}

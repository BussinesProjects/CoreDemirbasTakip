using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemirbasTakipSistemi.Migrations
{
    public partial class removedProjProd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_People_PersonID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProjectProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Products_PersonID",
                table: "Product",
                newName: "IX_Product_PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryID",
                table: "Product",
                newName: "IX_Product_CategoryID");

            migrationBuilder.AddColumn<string>(
                name: "ProductModel",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductProvider",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductServiceContact",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductWarrantyFinishDate",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ProductWarrantyStartDate",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ProjectCode",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectCode1",
                table: "Product",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProjectCode1",
                table: "Product",
                column: "ProjectCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categories_CategoryID",
                table: "Product",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_People_PersonID",
                table: "Product",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Projects_ProjectCode1",
                table: "Product",
                column: "ProjectCode1",
                principalTable: "Projects",
                principalColumn: "ProjectCode",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categories_CategoryID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_People_PersonID",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Projects_ProjectCode1",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProjectCode1",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductModel",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductProvider",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductServiceContact",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductWarrantyFinishDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductWarrantyStartDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProjectCode",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProjectCode1",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Product_PersonID",
                table: "Products",
                newName: "IX_Products_PersonID");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryID",
                table: "Products",
                newName: "IX_Products_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ProjectProducts",
                columns: table => new
                {
                    ProductSerialNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProductAmount = table.Column<int>(type: "int", nullable: false),
                    ProductBrand = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductFeatures = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductModel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductServiceContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductWarrantyFinishDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProductWarrantyStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProjectCode1 = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    RegisterDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    isEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProducts", x => x.ProductSerialNumber);
                    table.ForeignKey(
                        name: "FK_ProjectProducts_Projects_ProjectCode1",
                        column: x => x.ProjectCode1,
                        principalTable: "Projects",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProducts_ProjectCode1",
                table: "ProjectProducts",
                column: "ProjectCode1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_People_PersonID",
                table: "Products",
                column: "PersonID",
                principalTable: "People",
                principalColumn: "PersonID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

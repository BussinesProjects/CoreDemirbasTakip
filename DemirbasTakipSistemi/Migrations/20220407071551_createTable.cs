using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DemirbasTakipSistemi.Migrations
{
    public partial class createTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryID);
                });

            migrationBuilder.CreateTable(
                name: "CurrentUserDatas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    currentUserRoleID = table.Column<int>(nullable: true),
                    currentUserName = table.Column<string>(nullable: true),
                    userID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentUserDatas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PersonName = table.Column<string>(nullable: true),
                    PersonContact = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonID);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectCode = table.Column<string>(nullable: false),
                    ProjectClient = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(nullable: true),
                    ProjectStartDate = table.Column<DateTime>(nullable: false),
                    ProjectStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectCode);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    RequestID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RequestUsername = table.Column<string>(nullable: true),
                    RequestSubjectTitle = table.Column<string>(nullable: true),
                    RequestCategoryName = table.Column<string>(nullable: true),
                    RequestDateTime = table.Column<DateTime>(nullable: false),
                    RequestMessage = table.Column<string>(nullable: true),
                    RequestReceiverID = table.Column<string>(nullable: true),
                    RequestStatus = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.RequestID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductSerialNumber = table.Column<string>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false),
                    ProductBrand = table.Column<string>(nullable: true),
                    PersonID = table.Column<int>(nullable: false),
                    RegisterDateTime = table.Column<DateTime>(nullable: false),
                    ProductAmount = table.Column<int>(nullable: false),
                    ProductWarrantyDate = table.Column<DateTime>(nullable: false),
                    ServiceContact = table.Column<string>(nullable: true),
                    ProductFeatures = table.Column<string>(nullable: true),
                    ProductImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Categories",
                        principalColumn: "CategoryID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_People_PersonID",
                        column: x => x.PersonID,
                        principalTable: "People",
                        principalColumn: "PersonID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectProducts",
                columns: table => new
                {
                    ProjectCode = table.Column<string>(nullable: false),
                    ProductSerialNumber = table.Column<string>(nullable: true),
                    ProductBrand = table.Column<string>(nullable: true),
                    ProductModel = table.Column<string>(nullable: true),
                    RegisterDateTime = table.Column<DateTime>(nullable: false),
                    ProductAmount = table.Column<int>(nullable: false),
                    ProductWarrantyStartDate = table.Column<DateTime>(nullable: false),
                    ProductServiceContact = table.Column<string>(nullable: true),
                    ProductFeatures = table.Column<string>(nullable: true),
                    ProductImage = table.Column<string>(nullable: true),
                    ProductWarrantyFinishDate = table.Column<DateTime>(nullable: false),
                    ProductProvider = table.Column<string>(nullable: true),
                    ProjectCode1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectProducts", x => x.ProjectCode);
                    table.ForeignKey(
                        name: "FK_ProjectProducts_Projects_ProjectCode1",
                        column: x => x.ProjectCode1,
                        principalTable: "Projects",
                        principalColumn: "ProjectCode",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Logins",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logins", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logins_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatchNotes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatchID = table.Column<int>(nullable: false),
                    PatchVersion = table.Column<string>(nullable: true),
                    PatchType = table.Column<string>(nullable: true),
                    PatchNote1 = table.Column<string>(nullable: true),
                    PatchDateTime = table.Column<DateTime>(nullable: true),
                    LoginId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatchNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatchNotes_Logins_LoginId",
                        column: x => x.LoginId,
                        principalTable: "Logins",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Logins_RoleId",
                table: "Logins",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PatchNotes_LoginId",
                table: "PatchNotes",
                column: "LoginId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Products_PersonID",
                table: "Products",
                column: "PersonID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectProducts_ProjectCode1",
                table: "ProjectProducts",
                column: "ProjectCode1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentUserDatas");

            migrationBuilder.DropTable(
                name: "PatchNotes");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProjectProducts");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "Logins");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

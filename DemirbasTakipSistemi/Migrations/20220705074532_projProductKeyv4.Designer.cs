﻿// <auto-generated />
using System;
using DemirbasTakipSistemi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemirbasTakipSistemi.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220705074532_projProductKeyv4")]
    partial class projProductKeyv4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemirbasTakipSistemi.Models.DataModel.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isEnabled")
                        .HasColumnType("bit");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("DemirbasTakipSistemi.Models.DataModel.CurrentUserData", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("currentUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("currentUserRoleID")
                        .HasColumnType("int");

                    b.Property<int?>("userID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("CurrentUserDatas");
                });

            modelBuilder.Entity("DemirbasTakipSistemi.Models.DataModel.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("DemirbasTakipSistemi.Models.DataModel.PatchNote", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("LoginId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("PatchDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PatchID")
                        .HasColumnType("int");

                    b.Property<string>("PatchNote1")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatchType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PatchVersion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LoginId");

                    b.ToTable("PatchNotes");
                });

            modelBuilder.Entity("DemirbasTakipSistemi.Models.DataModel.Person", b =>
                {
                    b.Property<int>("PersonID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("PersonContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PersonName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isEnabled")
                        .HasColumnType("bit");

                    b.HasKey("PersonID");

                    b.ToTable("People");
                });

            modelBuilder.Entity("DemirbasTakipSistemi.Models.DataModel.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("PersonID")
                        .HasColumnType("int");

                    b.Property<int>("ProductAmount")
                        .HasColumnType("int");

                    b.Property<string>("ProductBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductFeatures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductSerialNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProductWarrantyDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("RegisterDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ServiceContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isEnabled")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("CategoryID");

                    b.HasIndex("PersonID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("DemirbasTakipSistemi.Models.DataModel.Project", b =>
                {
                    b.Property<string>("ProjectCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProjectClient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProjectStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectStatus")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("isEnabled")
                        .HasColumnType("bit");

                    b.HasKey("ProjectCode");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("DemirbasTakipSistemi.Models.DataModel.ProjectProduct", b =>
                {
                    b.Property<string>("ProductSerialNumber")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ProductAmount")
                        .HasColumnType("int");

                    b.Property<string>("ProductBrand")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductFeatures")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductImage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductModel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProductServiceContact")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ProductWarrantyFinishDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ProductWarrantyStartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ProjectCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProjectCode1")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("RegisterDateTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("isEnabled")
                        .HasColumnType("bit");

                    b.HasKey("ProductSerialNumber");

                    b.HasIndex("ProjectCode1");

                    b.ToTable("ProjectProducts");
                });

            modelBuilder.Entity("DemirbasTakipSistemi.Models.DataModel.Request", b =>
                {
                    b.Property<int>("RequestID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RequestCategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RequestDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("RequestMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestReceiverID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("RequestStatus")
                        .HasColumnType("bit");

                    b.Property<string>("RequestSubjectTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestUsername")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RequestID");

                    b.ToTable("Requests");
                });

            modelBuilder.Entity("DemirbasTakipSistemi.Models.DataModel.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RoleName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("DemirbasTakipSistemi.Models.DataModel.Login", b =>
                {
                    b.HasOne("DemirbasTakipSistemi.Models.DataModel.Role", "Role")
                        .WithMany("Logins")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DemirbasTakipSistemi.Models.DataModel.PatchNote", b =>
                {
                    b.HasOne("DemirbasTakipSistemi.Models.DataModel.Login", "Login")
                        .WithMany("PatchNotes")
                        .HasForeignKey("LoginId");
                });

            modelBuilder.Entity("DemirbasTakipSistemi.Models.DataModel.Product", b =>
                {
                    b.HasOne("DemirbasTakipSistemi.Models.DataModel.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DemirbasTakipSistemi.Models.DataModel.Person", "Person")
                        .WithMany("Products")
                        .HasForeignKey("PersonID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DemirbasTakipSistemi.Models.DataModel.ProjectProduct", b =>
                {
                    b.HasOne("DemirbasTakipSistemi.Models.DataModel.Project", "Project")
                        .WithMany("ProjectProducts")
                        .HasForeignKey("ProjectCode1");
                });
#pragma warning restore 612, 618
        }
    }
}

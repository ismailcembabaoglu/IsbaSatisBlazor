﻿// <auto-generated />
using System;
using IsbaSatisBlazor.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace IsbaSatisBlazor.Data.Migrations
{
    [DbContext(typeof(IsbaSatisDbContext))]
    [Migration("20231205191532_mig_userrole")]
    partial class mig_userrole
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("Id")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedUser")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Decription")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UpdatedUser")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable((string)null);

                    b.UseTpcMappingStrategy();
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Address", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("County")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("PhoneAdressType")
                        .HasColumnType("int");

                    b.HasIndex("CustomerId");

                    b.ToTable("Addreses", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Adisyon", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<int>("AdisyonDurum")
                        .HasColumnType("int");

                    b.Property<Guid?>("CustomerId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DeskId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Discount")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<Guid?>("GarsonId")
                        .IsRequired()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("TotalAmount")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DeskId");

                    b.HasIndex("GarsonId");

                    b.ToTable("Adisyons", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Customer", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<string>("CardNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("CustomerSurname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CustomerType")
                        .HasColumnType("int");

                    b.ToTable("Customers", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Desk", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<int>("Capacity")
                        .HasColumnType("int");

                    b.Property<Guid>("DeskLocationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsFull")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasIndex("DeskLocationId");

                    b.ToTable("Desks", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.DeskLocation", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<string>("LocationName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("DeskLocations", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Garson", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("Garsons", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.LinkTest", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Link")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Magaza")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PageEnd")
                        .HasColumnType("int");

                    b.Property<int>("PageStart")
                        .HasColumnType("int");

                    b.ToTable("Tests", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.PaymentMotion", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<Guid>("AdisyonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("PaymentTypeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasIndex("AdisyonId");

                    b.HasIndex("PaymentTypeId");

                    b.ToTable("PaymentMotions", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.PaymentType", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<string>("PaymentName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.ToTable("PaymentTypes", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Phone", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PhoneAdressType")
                        .HasColumnType("int");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasIndex("CustomerId");

                    b.ToTable("Phones", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Portion", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("SupplementaryMaterialMultiplier")
                        .HasPrecision(4, 2)
                        .HasColumnType("decimal(4,2)");

                    b.Property<Guid>("UnitId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ProductId");

                    b.HasIndex("UnitId");

                    b.ToTable("Portions", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Product", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<string>("Barcode")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Photo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProductGroupId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasIndex("ProductGroupId");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.ProductGroup", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("ProductGroups", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.ProductMotion", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<Guid>("AdisyonId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Amount")
                        .HasPrecision(8, 3)
                        .HasColumnType("decimal(8,3)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<Guid>("PortionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProductMotionType")
                        .HasColumnType("int");

                    b.Property<decimal>("Sale")
                        .HasPrecision(5, 2)
                        .HasColumnType("decimal(5,2)");

                    b.Property<decimal>("SupplementaryMaterialPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("UnitPrice")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.HasIndex("AdisyonId");

                    b.HasIndex("PortionId");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductMotions", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.ProductNote", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductNotes", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.SupplementaryMaterial", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SupplementaryMaterialName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasIndex("ProductId");

                    b.ToTable("SupplementaryMaterials", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.SupplementaryMaterialMotion", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<decimal>("Price")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<Guid>("ProductMotionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SupplementaryMaterialId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("ProductMotionId");

                    b.HasIndex("SupplementaryMaterialId");

                    b.ToTable("SupplementaryMaterialMotions", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Unit", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<string>("GroupName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Units", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.UserRole", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<int>("RoleType")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Users", b =>
                {
                    b.HasBaseType("IsbaSatisBlazor.Data.Models.BaseModel.ModelBase");

                    b.Property<string>("EMailAddress")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Address", b =>
                {
                    b.HasOne("IsbaSatisBlazor.Data.Models.Customer", "Customer")
                        .WithMany("Addresses")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Adisyon", b =>
                {
                    b.HasOne("IsbaSatisBlazor.Data.Models.Customer", "Customer")
                        .WithMany("Adisyons")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IsbaSatisBlazor.Data.Models.Desk", "Desk")
                        .WithMany("Adisyons")
                        .HasForeignKey("DeskId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IsbaSatisBlazor.Data.Models.Garson", "Garson")
                        .WithMany("Adisyons")
                        .HasForeignKey("GarsonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Desk");

                    b.Navigation("Garson");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Desk", b =>
                {
                    b.HasOne("IsbaSatisBlazor.Data.Models.DeskLocation", "DeskLocation")
                        .WithMany("Desks")
                        .HasForeignKey("DeskLocationId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("DeskLocation");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.PaymentMotion", b =>
                {
                    b.HasOne("IsbaSatisBlazor.Data.Models.Adisyon", "Adisyon")
                        .WithMany("PaymentMotions")
                        .HasForeignKey("AdisyonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IsbaSatisBlazor.Data.Models.PaymentType", "PaymentType")
                        .WithMany("PaymentMotions")
                        .HasForeignKey("PaymentTypeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Adisyon");

                    b.Navigation("PaymentType");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Phone", b =>
                {
                    b.HasOne("IsbaSatisBlazor.Data.Models.Customer", "Customer")
                        .WithMany("Phones")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Portion", b =>
                {
                    b.HasOne("IsbaSatisBlazor.Data.Models.Product", "Product")
                        .WithMany("Portions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IsbaSatisBlazor.Data.Models.Unit", "Unit")
                        .WithMany("Portions")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Product", b =>
                {
                    b.HasOne("IsbaSatisBlazor.Data.Models.ProductGroup", "ProductGroup")
                        .WithMany("Products")
                        .HasForeignKey("ProductGroupId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProductGroup");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.ProductMotion", b =>
                {
                    b.HasOne("IsbaSatisBlazor.Data.Models.Adisyon", "Adisyon")
                        .WithMany("ProductMotions")
                        .HasForeignKey("AdisyonId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IsbaSatisBlazor.Data.Models.Portion", "Portion")
                        .WithMany("ProductMotions")
                        .HasForeignKey("PortionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IsbaSatisBlazor.Data.Models.Product", "Product")
                        .WithMany("ProductMotions")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Adisyon");

                    b.Navigation("Portion");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.ProductNote", b =>
                {
                    b.HasOne("IsbaSatisBlazor.Data.Models.Product", "Product")
                        .WithMany("ProductNotes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.SupplementaryMaterial", b =>
                {
                    b.HasOne("IsbaSatisBlazor.Data.Models.Product", "Product")
                        .WithMany("SupplementaryMaterials")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Product");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.SupplementaryMaterialMotion", b =>
                {
                    b.HasOne("IsbaSatisBlazor.Data.Models.ProductMotion", "ProductMotion")
                        .WithMany("SupplementaryMaterialMotions")
                        .HasForeignKey("ProductMotionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("IsbaSatisBlazor.Data.Models.SupplementaryMaterial", "SupplementaryMaterial")
                        .WithMany("SupplementaryMaterialMotions")
                        .HasForeignKey("SupplementaryMaterialId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("ProductMotion");

                    b.Navigation("SupplementaryMaterial");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.UserRole", b =>
                {
                    b.HasOne("IsbaSatisBlazor.Data.Models.Users", "Users")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Users");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Adisyon", b =>
                {
                    b.Navigation("PaymentMotions");

                    b.Navigation("ProductMotions");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Customer", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Adisyons");

                    b.Navigation("Phones");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Desk", b =>
                {
                    b.Navigation("Adisyons");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.DeskLocation", b =>
                {
                    b.Navigation("Desks");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Garson", b =>
                {
                    b.Navigation("Adisyons");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.PaymentType", b =>
                {
                    b.Navigation("PaymentMotions");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Portion", b =>
                {
                    b.Navigation("ProductMotions");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Product", b =>
                {
                    b.Navigation("Portions");

                    b.Navigation("ProductMotions");

                    b.Navigation("ProductNotes");

                    b.Navigation("SupplementaryMaterials");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.ProductGroup", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.ProductMotion", b =>
                {
                    b.Navigation("SupplementaryMaterialMotions");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.SupplementaryMaterial", b =>
                {
                    b.Navigation("SupplementaryMaterialMotions");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Unit", b =>
                {
                    b.Navigation("Portions");
                });

            modelBuilder.Entity("IsbaSatisBlazor.Data.Models.Users", b =>
                {
                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}

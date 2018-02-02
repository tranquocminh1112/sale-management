﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using SaleManagement.Models;
using System;

namespace SaleManagement.Migrations
{
    [DbContext(typeof(SaleManagementDbContext))]
    [Migration("20180202070628_InitDB")]
    partial class InitDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn)
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125");

            modelBuilder.Entity("SaleManagement.Models.Area", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Area");
                });

            modelBuilder.Entity("SaleManagement.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("SaleManagement.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("SaleManagement.Models.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AreaId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<double>("Credit");

                    b.Property<string>("CreditOrderId");

                    b.Property<double>("Debt");

                    b.Property<string>("DebtOrderId");

                    b.Property<string>("Description");

                    b.Property<string>("MainContactNumber");

                    b.Property<string>("MainContactPerson");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.Property<string>("SubContactNumber");

                    b.Property<string>("SubContactPerson");

                    b.HasKey("Id");

                    b.HasIndex("AreaId");

                    b.HasIndex("CreditOrderId");

                    b.HasIndex("DebtOrderId");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("SaleManagement.Models.CustomerTransporter", b =>
                {
                    b.Property<int>("CustomerId");

                    b.Property<int>("TransporterId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.HasKey("CustomerId", "TransporterId");

                    b.HasIndex("TransporterId");

                    b.ToTable("CustomerTransporter");
                });

            modelBuilder.Entity("SaleManagement.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("SaleManagement.Models.Order", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<int?>("CustomerId");

                    b.Property<int?>("DetailId");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Note");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Status");

                    b.Property<int?>("TransporterId");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.HasIndex("DetailId")
                        .IsUnique();

                    b.HasIndex("ProductId");

                    b.HasIndex("TransporterId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("SaleManagement.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<double>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<int>("Quantity");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("SaleManagement.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CategoryId");

                    b.Property<int?>("CompanyId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<int?>("GroupId");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<string>("Photo");

                    b.Property<double>("Price");

                    b.Property<int?>("Quantity");

                    b.Property<int>("Status");

                    b.Property<int?>("SupplierId");

                    b.Property<int?>("TagId");

                    b.Property<int?>("TypeId");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CompanyId");

                    b.HasIndex("GroupId");

                    b.HasIndex("SupplierId");

                    b.HasIndex("TagId");

                    b.HasIndex("TypeId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("SaleManagement.Models.Supplier", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<string>("MainContactNumber");

                    b.Property<string>("MainContactPerson");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.Property<string>("SubContactNumber");

                    b.Property<string>("SubContactPerson");

                    b.HasKey("Id");

                    b.ToTable("Supplier");
                });

            modelBuilder.Entity("SaleManagement.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("SaleManagement.Models.Transporter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<string>("Description");

                    b.Property<int?>("DestinationId");

                    b.Property<string>("MainContactNumber");

                    b.Property<string>("MainContactPerson");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.Property<string>("SubContactNumber");

                    b.Property<string>("SubContactPerson");

                    b.HasKey("Id");

                    b.HasIndex("DestinationId");

                    b.ToTable("Transporter");
                });

            modelBuilder.Entity("SaleManagement.Models.Type", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("ModifiedAt");

                    b.Property<string>("ModifiedBy");

                    b.Property<string>("Name");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Type");
                });

            modelBuilder.Entity("SaleManagement.Models.Customer", b =>
                {
                    b.HasOne("SaleManagement.Models.Area", "Area")
                        .WithMany("Customers")
                        .HasForeignKey("AreaId");

                    b.HasOne("SaleManagement.Models.Order", "CreditOrder")
                        .WithMany()
                        .HasForeignKey("CreditOrderId");

                    b.HasOne("SaleManagement.Models.Order", "DebtOrder")
                        .WithMany()
                        .HasForeignKey("DebtOrderId");
                });

            modelBuilder.Entity("SaleManagement.Models.CustomerTransporter", b =>
                {
                    b.HasOne("SaleManagement.Models.Customer", "Customer")
                        .WithMany("Transporters")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SaleManagement.Models.Transporter", "Transporter")
                        .WithMany("Customer")
                        .HasForeignKey("TransporterId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SaleManagement.Models.Order", b =>
                {
                    b.HasOne("SaleManagement.Models.Customer")
                        .WithMany("Orders")
                        .HasForeignKey("CustomerId");

                    b.HasOne("SaleManagement.Models.OrderDetail", "Detail")
                        .WithOne("Order")
                        .HasForeignKey("SaleManagement.Models.Order", "DetailId");

                    b.HasOne("SaleManagement.Models.Product")
                        .WithMany("Orders")
                        .HasForeignKey("ProductId");

                    b.HasOne("SaleManagement.Models.Transporter", "Transporter")
                        .WithMany()
                        .HasForeignKey("TransporterId");
                });

            modelBuilder.Entity("SaleManagement.Models.OrderDetail", b =>
                {
                    b.HasOne("SaleManagement.Models.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("SaleManagement.Models.Product", b =>
                {
                    b.HasOne("SaleManagement.Models.Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");

                    b.HasOne("SaleManagement.Models.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId");

                    b.HasOne("SaleManagement.Models.Group", "Group")
                        .WithMany("Products")
                        .HasForeignKey("GroupId");

                    b.HasOne("SaleManagement.Models.Supplier", "Supplier")
                        .WithMany("Products")
                        .HasForeignKey("SupplierId");

                    b.HasOne("SaleManagement.Models.Tag")
                        .WithMany("Products")
                        .HasForeignKey("TagId");

                    b.HasOne("SaleManagement.Models.Type", "Type")
                        .WithMany("Products")
                        .HasForeignKey("TypeId");
                });

            modelBuilder.Entity("SaleManagement.Models.Transporter", b =>
                {
                    b.HasOne("SaleManagement.Models.Area", "Destination")
                        .WithMany("Transporters")
                        .HasForeignKey("DestinationId");
                });
#pragma warning restore 612, 618
        }
    }
}

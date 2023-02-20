﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(EreftSystemDbContext))]
    [Migration("20230220141733_OrderStatusSeedData")]
    partial class OrderStatusSeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Core.Entities.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CatagoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CatagoryId");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("Core.Entities.MenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GroupId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<float>("UnitPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("MenuItem");
                });

            modelBuilder.Entity("Core.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderStatusId")
                        .HasColumnType("integer");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("CreatedBy");

                    b.HasIndex("OrderStatusId");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Core.Entities.OrderMenuItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("MenuItemId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("OrderId")
                        .HasColumnType("integer");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.HasIndex("MenuItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderMenuItem");
                });

            modelBuilder.Entity("Core.Entities.OrderStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("OrderStatus");
                });

            modelBuilder.Entity("Core.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("CreateDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ModifiedDateTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<int?>("RoleId")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("Core.Entities.Group", b =>
                {
                    b.HasOne("Core.Entities.Category", "Catagory")
                        .WithMany("Groups")
                        .HasForeignKey("CatagoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catagory");
                });

            modelBuilder.Entity("Core.Entities.MenuItem", b =>
                {
                    b.HasOne("Core.Entities.Group", "Group")
                        .WithMany("MenuItems")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Core.Entities.Order", b =>
                {
                    b.HasOne("Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("CreatedBy")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.OrderStatus", "OrderStatus")
                        .WithMany()
                        .HasForeignKey("OrderStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderStatus");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Core.Entities.OrderMenuItem", b =>
                {
                    b.HasOne("Core.Entities.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Core.Entities.Order", "Order")
                        .WithMany("OrderMenuItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MenuItem");

                    b.Navigation("Order");
                });

            modelBuilder.Entity("Core.Entities.User", b =>
                {
                    b.HasOne("Core.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Core.Entities.Category", b =>
                {
                    b.Navigation("Groups");
                });

            modelBuilder.Entity("Core.Entities.Group", b =>
                {
                    b.Navigation("MenuItems");
                });

            modelBuilder.Entity("Core.Entities.Order", b =>
                {
                    b.Navigation("OrderMenuItems");
                });
#pragma warning restore 612, 618
        }
    }
}

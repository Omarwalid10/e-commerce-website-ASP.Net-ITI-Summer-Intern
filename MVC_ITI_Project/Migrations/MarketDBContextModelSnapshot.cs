﻿// <auto-generated />
using MVC_ITI_Project.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MVC_ITI_Project.Migrations
{
    [DbContext(typeof(MarketDBContext))]
    partial class MarketDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MVC_ITI_Project.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("userId");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("MVC_ITI_Project.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<int>("sellerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("sellerId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("MVC_ITI_Project.Models.Seller", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("sellers");
                });

            modelBuilder.Entity("MVC_ITI_Project.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("passward")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("ordersId")
                        .HasColumnType("int");

                    b.Property<int>("productsId")
                        .HasColumnType("int");

                    b.HasKey("ordersId", "productsId");

                    b.HasIndex("productsId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("MVC_ITI_Project.Models.Order", b =>
                {
                    b.HasOne("MVC_ITI_Project.Models.User", "User")
                        .WithMany("orders")
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("MVC_ITI_Project.Models.Product", b =>
                {
                    b.HasOne("MVC_ITI_Project.Models.Seller", "seller")
                        .WithMany("products")
                        .HasForeignKey("sellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("seller");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("MVC_ITI_Project.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("ordersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVC_ITI_Project.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("productsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVC_ITI_Project.Models.Seller", b =>
                {
                    b.Navigation("products");
                });

            modelBuilder.Entity("MVC_ITI_Project.Models.User", b =>
                {
                    b.Navigation("orders");
                });
#pragma warning restore 612, 618
        }
    }
}

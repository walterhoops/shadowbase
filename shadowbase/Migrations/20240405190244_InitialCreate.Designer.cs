﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using shadowbase.Data;

#nullable disable

namespace shadowbase.Migrations
{
    [DbContext(typeof(ShadowbaseContext))]
    [Migration("20240405190244_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AdminAuction", b =>
                {
                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<int>("AuctionsAuctionID")
                        .HasColumnType("int");

                    b.HasKey("AdminID", "AuctionsAuctionID");

                    b.HasIndex("AuctionsAuctionID");

                    b.ToTable("AdminAuction");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Department", b =>
                {
                    b.Property<int>("DepartmentID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DepartmentID"));

                    b.Property<int?>("AdminID")
                        .HasColumnType("int");

                    b.Property<decimal>("Budget")
                        .HasColumnType("money");

                    b.Property<string>("Name")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DepartmentID");

                    b.HasIndex("AdminID");

                    b.ToTable("Departments", (string)null);
                });

            modelBuilder.Entity("shadowbase.Models.Admin", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("FirstMidName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("FirstName");

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ID");

                    b.ToTable("Admin", (string)null);
                });

            modelBuilder.Entity("shadowbase.Models.AdminAssignment", b =>
                {
                    b.Property<int>("AdminID")
                        .HasColumnType("int");

                    b.Property<string>("Location")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AdminID");

                    b.ToTable("AdminAssignments");
                });

            modelBuilder.Entity("shadowbase.Models.Auction", b =>
                {
                    b.Property<int>("AuctionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AuctionID"));

                    b.Property<int>("AuctionStatusIDFK")
                        .HasColumnType("int");

                    b.Property<int>("AuctionTypeIDFK")
                        .HasColumnType("int");

                    b.Property<decimal>("BidLimit")
                        .HasColumnType("decimal(3, 2)");

                    b.Property<int>("ClientIDFK")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("HomeBudget")
                        .HasColumnType("int");

                    b.Property<int>("UserIDFK")
                        .HasColumnType("int");

                    b.HasKey("AuctionID");

                    b.HasIndex("AuctionStatusIDFK");

                    b.HasIndex("AuctionTypeIDFK");

                    b.HasIndex("ClientIDFK");

                    b.HasIndex("DepartmentID");

                    b.HasIndex("UserIDFK");

                    b.ToTable("Auction", (string)null);
                });

            modelBuilder.Entity("shadowbase.Models.AuctionStatus", b =>
                {
                    b.Property<int>("AuctionStatusID")
                        .HasColumnType("int");

                    b.Property<string>("AuctionStatusDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AuctionStatusID");

                    b.ToTable("AuctionStatus", (string)null);
                });

            modelBuilder.Entity("shadowbase.Models.AuctionType", b =>
                {
                    b.Property<int>("AuctionTypeID")
                        .HasColumnType("int");

                    b.Property<string>("AuctionTypeDescription")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("AuctionTypeID");

                    b.ToTable("AuctionType", (string)null);
                });

            modelBuilder.Entity("shadowbase.Models.Bid", b =>
                {
                    b.Property<int>("BidID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BidID"));

                    b.Property<int>("AuctionIDFK")
                        .HasColumnType("int");

                    b.Property<decimal>("BidAmount")
                        .HasColumnType("decimal(3, 2)");

                    b.Property<DateTime>("BidDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserIDFK")
                        .HasColumnType("int");

                    b.HasKey("BidID");

                    b.HasIndex("AuctionIDFK");

                    b.HasIndex("UserIDFK");

                    b.ToTable("Bid", (string)null);
                });

            modelBuilder.Entity("shadowbase.Models.Client", b =>
                {
                    b.Property<int>("ClientID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClientID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnName("First Name");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientID");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("shadowbase.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserID"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LicenseID")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PayPalEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTypeIDFK")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("UserID");

                    b.HasIndex("UserTypeIDFK");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("shadowbase.Models.UserType", b =>
                {
                    b.Property<int>("UserTypeID")
                        .HasColumnType("int");

                    b.Property<string>("UserTypeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserTypeID");

                    b.ToTable("UserType", (string)null);
                });

            modelBuilder.Entity("AdminAuction", b =>
                {
                    b.HasOne("shadowbase.Models.Admin", null)
                        .WithMany()
                        .HasForeignKey("AdminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shadowbase.Models.Auction", null)
                        .WithMany()
                        .HasForeignKey("AuctionsAuctionID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ContosoUniversity.Models.Department", b =>
                {
                    b.HasOne("shadowbase.Models.Admin", "Administrator")
                        .WithMany()
                        .HasForeignKey("AdminID");

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("shadowbase.Models.AdminAssignment", b =>
                {
                    b.HasOne("shadowbase.Models.Admin", "Admin")
                        .WithOne("AdminAssignment")
                        .HasForeignKey("shadowbase.Models.AdminAssignment", "AdminID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("shadowbase.Models.Auction", b =>
                {
                    b.HasOne("shadowbase.Models.AuctionStatus", "AuctionStatus")
                        .WithMany("Auctions")
                        .HasForeignKey("AuctionStatusIDFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shadowbase.Models.AuctionType", "AuctionType")
                        .WithMany("Auctions")
                        .HasForeignKey("AuctionTypeIDFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shadowbase.Models.Client", "Client")
                        .WithMany("Auctions")
                        .HasForeignKey("ClientIDFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ContosoUniversity.Models.Department", "Department")
                        .WithMany("Auction")
                        .HasForeignKey("DepartmentID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shadowbase.Models.User", "User")
                        .WithMany("Auctions")
                        .HasForeignKey("UserIDFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AuctionStatus");

                    b.Navigation("AuctionType");

                    b.Navigation("Client");

                    b.Navigation("Department");

                    b.Navigation("User");
                });

            modelBuilder.Entity("shadowbase.Models.Bid", b =>
                {
                    b.HasOne("shadowbase.Models.Auction", "Auction")
                        .WithMany("Bids")
                        .HasForeignKey("AuctionIDFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shadowbase.Models.User", "User")
                        .WithMany("Bids")
                        .HasForeignKey("UserIDFK");

                    b.Navigation("Auction");

                    b.Navigation("User");
                });

            modelBuilder.Entity("shadowbase.Models.User", b =>
                {
                    b.HasOne("shadowbase.Models.UserType", "UserType")
                        .WithMany("Users")
                        .HasForeignKey("UserTypeIDFK")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserType");
                });

            modelBuilder.Entity("ContosoUniversity.Models.Department", b =>
                {
                    b.Navigation("Auction");
                });

            modelBuilder.Entity("shadowbase.Models.Admin", b =>
                {
                    b.Navigation("AdminAssignment");
                });

            modelBuilder.Entity("shadowbase.Models.Auction", b =>
                {
                    b.Navigation("Bids");
                });

            modelBuilder.Entity("shadowbase.Models.AuctionStatus", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("shadowbase.Models.AuctionType", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("shadowbase.Models.Client", b =>
                {
                    b.Navigation("Auctions");
                });

            modelBuilder.Entity("shadowbase.Models.User", b =>
                {
                    b.Navigation("Auctions");

                    b.Navigation("Bids");
                });

            modelBuilder.Entity("shadowbase.Models.UserType", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}

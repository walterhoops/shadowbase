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
    [DbContext(typeof(shadowbaseContext))]
    [Migration("20240220085648_DBTest")]
    partial class DBTest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AuctionBidDataAuctionData", b =>
                {
                    b.Property<int>("AuctionBidDataId")
                        .HasColumnType("int");

                    b.Property<int>("AuctionDataId")
                        .HasColumnType("int");

                    b.HasKey("AuctionBidDataId", "AuctionDataId");

                    b.HasIndex("AuctionDataId");

                    b.ToTable("AuctionBidDataAuctionData");
                });

            modelBuilder.Entity("AuctionBidDataUserData", b =>
                {
                    b.Property<int>("AuctionBidDataId")
                        .HasColumnType("int");

                    b.Property<int>("UserDataId")
                        .HasColumnType("int");

                    b.HasKey("AuctionBidDataId", "UserDataId");

                    b.HasIndex("UserDataId");

                    b.ToTable("AuctionBidDataUserData");
                });

            modelBuilder.Entity("AuctionDataClientData", b =>
                {
                    b.Property<int>("AuctionDataId")
                        .HasColumnType("int");

                    b.Property<int>("ClientDataId")
                        .HasColumnType("int");

                    b.HasKey("AuctionDataId", "ClientDataId");

                    b.HasIndex("ClientDataId");

                    b.ToTable("AuctionDataClientData");
                });

            modelBuilder.Entity("AuctionDataStatusIDs", b =>
                {
                    b.Property<int>("AuctionDataId")
                        .HasColumnType("int");

                    b.Property<int>("StatusIDsId")
                        .HasColumnType("int");

                    b.HasKey("AuctionDataId", "StatusIDsId");

                    b.HasIndex("StatusIDsId");

                    b.ToTable("AuctionDataStatusIDs");
                });

            modelBuilder.Entity("AuctionDataUserData", b =>
                {
                    b.Property<int>("AuctionDataId")
                        .HasColumnType("int");

                    b.Property<int>("UserDataId")
                        .HasColumnType("int");

                    b.HasKey("AuctionDataId", "UserDataId");

                    b.HasIndex("UserDataId");

                    b.ToTable("AuctionDataUserData");
                });

            modelBuilder.Entity("LicenseDataUserData", b =>
                {
                    b.Property<int>("LicenseDataId")
                        .HasColumnType("int");

                    b.Property<int>("UserDataId")
                        .HasColumnType("int");

                    b.HasKey("LicenseDataId", "UserDataId");

                    b.HasIndex("UserDataId");

                    b.ToTable("LicenseDataUserData");
                });

            modelBuilder.Entity("shadowbase.Models.AuctionBidData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<decimal>("BidAmount")
                        .HasColumnType("decimal(2, 2)");

                    b.Property<DateTime>("BidDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AuctionBidData", (string)null);
                });

            modelBuilder.Entity("shadowbase.Models.AuctionData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BidID")
                        .HasColumnType("int");

                    b.Property<decimal>("BidLimit")
                        .HasColumnType("decimal(2, 2)");

                    b.Property<int>("ClientID")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("HomeBudget")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("StatusID")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AuctionData", (string)null);
                });

            modelBuilder.Entity("shadowbase.Models.ClientData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClientData", (string)null);
                });

            modelBuilder.Entity("shadowbase.Models.LicenseData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("UserID")
                        .HasColumnType("int");

                    b.Property<string>("hiLicense")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("mbLicense")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("reLicense")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("LicenseData", (string)null);
                });

            modelBuilder.Entity("shadowbase.Models.StatusIDs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("StatusDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StatusID")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("StatusIDs", (string)null);
                });

            modelBuilder.Entity("shadowbase.Models.UserData", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PayPalEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeID")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserTypesId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserTypesId");

                    b.ToTable("UserData", (string)null);
                });

            modelBuilder.Entity("shadowbase.Models.UserTypes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("TypeDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TypeID")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserTypes", (string)null);
                });

            modelBuilder.Entity("AuctionBidDataAuctionData", b =>
                {
                    b.HasOne("shadowbase.Models.AuctionBidData", null)
                        .WithMany()
                        .HasForeignKey("AuctionBidDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shadowbase.Models.AuctionData", null)
                        .WithMany()
                        .HasForeignKey("AuctionDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuctionBidDataUserData", b =>
                {
                    b.HasOne("shadowbase.Models.AuctionBidData", null)
                        .WithMany()
                        .HasForeignKey("AuctionBidDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shadowbase.Models.UserData", null)
                        .WithMany()
                        .HasForeignKey("UserDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuctionDataClientData", b =>
                {
                    b.HasOne("shadowbase.Models.AuctionData", null)
                        .WithMany()
                        .HasForeignKey("AuctionDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shadowbase.Models.ClientData", null)
                        .WithMany()
                        .HasForeignKey("ClientDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuctionDataStatusIDs", b =>
                {
                    b.HasOne("shadowbase.Models.AuctionData", null)
                        .WithMany()
                        .HasForeignKey("AuctionDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shadowbase.Models.StatusIDs", null)
                        .WithMany()
                        .HasForeignKey("StatusIDsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AuctionDataUserData", b =>
                {
                    b.HasOne("shadowbase.Models.AuctionData", null)
                        .WithMany()
                        .HasForeignKey("AuctionDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shadowbase.Models.UserData", null)
                        .WithMany()
                        .HasForeignKey("UserDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LicenseDataUserData", b =>
                {
                    b.HasOne("shadowbase.Models.LicenseData", null)
                        .WithMany()
                        .HasForeignKey("LicenseDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("shadowbase.Models.UserData", null)
                        .WithMany()
                        .HasForeignKey("UserDataId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("shadowbase.Models.UserData", b =>
                {
                    b.HasOne("shadowbase.Models.UserTypes", "UserTypes")
                        .WithMany("UserData")
                        .HasForeignKey("UserTypesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserTypes");
                });

            modelBuilder.Entity("shadowbase.Models.UserTypes", b =>
                {
                    b.Navigation("UserData");
                });
#pragma warning restore 612, 618
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shadowbase.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuctionStatus",
                columns: table => new
                {
                    AuctionStatusID = table.Column<int>(type: "int", nullable: false),
                    AuctionStatusDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionStatus", x => x.AuctionStatusID);
                });

            migrationBuilder.CreateTable(
                name: "AuctionType",
                columns: table => new
                {
                    AuctionTypeID = table.Column<int>(type: "int", nullable: false),
                    AuctionTypeDescription = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionType", x => x.AuctionTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(name: "First Name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                });

            migrationBuilder.CreateTable(
                name: "Instructor",
                columns: table => new
                {
                    InstrutorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(name: "First Name", type: "nvarchar(50)", maxLength: 50, nullable: false),
                    HireDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instructor", x => x.InstrutorID);
                });

            migrationBuilder.CreateTable(
                name: "UserType",
                columns: table => new
                {
                    UserTypeID = table.Column<int>(type: "int", nullable: false),
                    UserTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserType", x => x.UserTypeID);
                });

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Budget = table.Column<decimal>(type: "money", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InstructorID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentID);
                    table.ForeignKey(
                        name: "FK_Departments_Instructor_InstructorID",
                        column: x => x.InstructorID,
                        principalTable: "Instructor",
                        principalColumn: "InstrutorID");
                });

            migrationBuilder.CreateTable(
                name: "OfficeAssignments",
                columns: table => new
                {
                    InstructorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    InstructorInstrutorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficeAssignments", x => x.InstructorID);
                    table.ForeignKey(
                        name: "FK_OfficeAssignments_Instructor_InstructorInstrutorID",
                        column: x => x.InstructorInstrutorID,
                        principalTable: "Instructor",
                        principalColumn: "InstrutorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserTypeIDFK = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DOB = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Company = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PayPalEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LicenseID = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                    table.ForeignKey(
                        name: "FK_User_UserType_UserTypeIDFK",
                        column: x => x.UserTypeIDFK,
                        principalTable: "UserType",
                        principalColumn: "UserTypeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Auction",
                columns: table => new
                {
                    AuctionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserIDFK = table.Column<int>(type: "int", nullable: false),
                    ClientIDFK = table.Column<int>(type: "int", nullable: false),
                    AuctionStatusIDFK = table.Column<int>(type: "int", nullable: false),
                    AuctionTypeIDFK = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HomeBudget = table.Column<int>(type: "int", nullable: false),
                    BidLimit = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    DepartmentID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Auction", x => x.AuctionID);
                    table.ForeignKey(
                        name: "FK_Auction_AuctionStatus_AuctionStatusIDFK",
                        column: x => x.AuctionStatusIDFK,
                        principalTable: "AuctionStatus",
                        principalColumn: "AuctionStatusID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auction_AuctionType_AuctionTypeIDFK",
                        column: x => x.AuctionTypeIDFK,
                        principalTable: "AuctionType",
                        principalColumn: "AuctionTypeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auction_Client_ClientIDFK",
                        column: x => x.ClientIDFK,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Auction_Departments_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "Departments",
                        principalColumn: "DepartmentID");
                    table.ForeignKey(
                        name: "FK_Auction_User_UserIDFK",
                        column: x => x.UserIDFK,
                        principalTable: "User",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionInstructor",
                columns: table => new
                {
                    AuctionsAuctionID = table.Column<int>(type: "int", nullable: false),
                    InstructorsInstrutorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionInstructor", x => new { x.AuctionsAuctionID, x.InstructorsInstrutorID });
                    table.ForeignKey(
                        name: "FK_AuctionInstructor_Auction_AuctionsAuctionID",
                        column: x => x.AuctionsAuctionID,
                        principalTable: "Auction",
                        principalColumn: "AuctionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionInstructor_Instructor_InstructorsInstrutorID",
                        column: x => x.InstructorsInstrutorID,
                        principalTable: "Instructor",
                        principalColumn: "InstrutorID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Bid",
                columns: table => new
                {
                    BidID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AuctionIDFK = table.Column<int>(type: "int", nullable: false),
                    UserIDFK = table.Column<int>(type: "int", nullable: true),
                    BidAmount = table.Column<decimal>(type: "decimal(3,2)", nullable: false),
                    BidDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bid", x => x.BidID);
                    table.ForeignKey(
                        name: "FK_Bid_Auction_AuctionIDFK",
                        column: x => x.AuctionIDFK,
                        principalTable: "Auction",
                        principalColumn: "AuctionID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bid_User_UserIDFK",
                        column: x => x.UserIDFK,
                        principalTable: "User",
                        principalColumn: "UserID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Auction_AuctionStatusIDFK",
                table: "Auction",
                column: "AuctionStatusIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_Auction_AuctionTypeIDFK",
                table: "Auction",
                column: "AuctionTypeIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_Auction_ClientIDFK",
                table: "Auction",
                column: "ClientIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_Auction_DepartmentID",
                table: "Auction",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_Auction_UserIDFK",
                table: "Auction",
                column: "UserIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionInstructor_InstructorsInstrutorID",
                table: "AuctionInstructor",
                column: "InstructorsInstrutorID");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_AuctionIDFK",
                table: "Bid",
                column: "AuctionIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_Bid_UserIDFK",
                table: "Bid",
                column: "UserIDFK");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_InstructorID",
                table: "Departments",
                column: "InstructorID");

            migrationBuilder.CreateIndex(
                name: "IX_OfficeAssignments_InstructorInstrutorID",
                table: "OfficeAssignments",
                column: "InstructorInstrutorID");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserTypeIDFK",
                table: "User",
                column: "UserTypeIDFK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AuctionInstructor");

            migrationBuilder.DropTable(
                name: "Bid");

            migrationBuilder.DropTable(
                name: "OfficeAssignments");

            migrationBuilder.DropTable(
                name: "Auction");

            migrationBuilder.DropTable(
                name: "AuctionStatus");

            migrationBuilder.DropTable(
                name: "AuctionType");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Instructor");

            migrationBuilder.DropTable(
                name: "UserType");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace shadowbase.Migrations
{
    /// <inheritdoc />
    public partial class CU : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserTypesId",
                table: "UserData",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AuctionBidDataAuctionData",
                columns: table => new
                {
                    AuctionBidDataId = table.Column<int>(type: "int", nullable: false),
                    AuctionDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionBidDataAuctionData", x => new { x.AuctionBidDataId, x.AuctionDataId });
                    table.ForeignKey(
                        name: "FK_AuctionBidDataAuctionData_AuctionBidData_AuctionBidDataId",
                        column: x => x.AuctionBidDataId,
                        principalTable: "AuctionBidData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionBidDataAuctionData_AuctionData_AuctionDataId",
                        column: x => x.AuctionDataId,
                        principalTable: "AuctionData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionBidDataUserData",
                columns: table => new
                {
                    AuctionBidDataId = table.Column<int>(type: "int", nullable: false),
                    UserDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionBidDataUserData", x => new { x.AuctionBidDataId, x.UserDataId });
                    table.ForeignKey(
                        name: "FK_AuctionBidDataUserData_AuctionBidData_AuctionBidDataId",
                        column: x => x.AuctionBidDataId,
                        principalTable: "AuctionBidData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionBidDataUserData_UserData_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "UserData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionDataClientData",
                columns: table => new
                {
                    AuctionDataId = table.Column<int>(type: "int", nullable: false),
                    ClientDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDataClientData", x => new { x.AuctionDataId, x.ClientDataId });
                    table.ForeignKey(
                        name: "FK_AuctionDataClientData_AuctionData_AuctionDataId",
                        column: x => x.AuctionDataId,
                        principalTable: "AuctionData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionDataClientData_ClientData_ClientDataId",
                        column: x => x.ClientDataId,
                        principalTable: "ClientData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionDataStatusIDs",
                columns: table => new
                {
                    AuctionDataId = table.Column<int>(type: "int", nullable: false),
                    StatusIDsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDataStatusIDs", x => new { x.AuctionDataId, x.StatusIDsId });
                    table.ForeignKey(
                        name: "FK_AuctionDataStatusIDs_AuctionData_AuctionDataId",
                        column: x => x.AuctionDataId,
                        principalTable: "AuctionData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionDataStatusIDs_StatusIDs_StatusIDsId",
                        column: x => x.StatusIDsId,
                        principalTable: "StatusIDs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuctionDataUserData",
                columns: table => new
                {
                    AuctionDataId = table.Column<int>(type: "int", nullable: false),
                    UserDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuctionDataUserData", x => new { x.AuctionDataId, x.UserDataId });
                    table.ForeignKey(
                        name: "FK_AuctionDataUserData_AuctionData_AuctionDataId",
                        column: x => x.AuctionDataId,
                        principalTable: "AuctionData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuctionDataUserData_UserData_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "UserData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LicenseDataUserData",
                columns: table => new
                {
                    LicenseDataId = table.Column<int>(type: "int", nullable: false),
                    UserDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LicenseDataUserData", x => new { x.LicenseDataId, x.UserDataId });
                    table.ForeignKey(
                        name: "FK_LicenseDataUserData_LicenseData_LicenseDataId",
                        column: x => x.LicenseDataId,
                        principalTable: "LicenseData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LicenseDataUserData_UserData_UserDataId",
                        column: x => x.UserDataId,
                        principalTable: "UserData",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserData_UserTypesId",
                table: "UserData",
                column: "UserTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionBidDataAuctionData_AuctionDataId",
                table: "AuctionBidDataAuctionData",
                column: "AuctionDataId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionBidDataUserData_UserDataId",
                table: "AuctionBidDataUserData",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDataClientData_ClientDataId",
                table: "AuctionDataClientData",
                column: "ClientDataId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDataStatusIDs_StatusIDsId",
                table: "AuctionDataStatusIDs",
                column: "StatusIDsId");

            migrationBuilder.CreateIndex(
                name: "IX_AuctionDataUserData_UserDataId",
                table: "AuctionDataUserData",
                column: "UserDataId");

            migrationBuilder.CreateIndex(
                name: "IX_LicenseDataUserData_UserDataId",
                table: "LicenseDataUserData",
                column: "UserDataId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserData_UserTypes_UserTypesId",
                table: "UserData",
                column: "UserTypesId",
                principalTable: "UserTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserData_UserTypes_UserTypesId",
                table: "UserData");

            migrationBuilder.DropTable(
                name: "AuctionBidDataAuctionData");

            migrationBuilder.DropTable(
                name: "AuctionBidDataUserData");

            migrationBuilder.DropTable(
                name: "AuctionDataClientData");

            migrationBuilder.DropTable(
                name: "AuctionDataStatusIDs");

            migrationBuilder.DropTable(
                name: "AuctionDataUserData");

            migrationBuilder.DropTable(
                name: "LicenseDataUserData");

            migrationBuilder.DropIndex(
                name: "IX_UserData_UserTypesId",
                table: "UserData");

            migrationBuilder.DropColumn(
                name: "UserTypesId",
                table: "UserData");
        }
    }
}

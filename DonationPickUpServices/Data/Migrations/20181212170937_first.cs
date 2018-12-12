using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DonationPickUpServices.Data.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserPhoneNumber",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserTypeId",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "ItemTypes",
                columns: table => new
                {
                    ItemTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypes", x => x.ItemTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    StatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.StatusId);
                });

            migrationBuilder.CreateTable(
                name: "UserTypes",
                columns: table => new
                {
                    UserTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTypes", x => x.UserTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    DonationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateCompleted = table.Column<DateTime>(nullable: true),
                    StatusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.DonationId);
                    table.ForeignKey(
                        name: "FK_Donations_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "StatusId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Items",
                columns: table => new
                {
                    ItemId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    ApplicationUserId = table.Column<string>(nullable: false),
                    ItemTypeId = table.Column<int>(nullable: false),
                    DonationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Items", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_Items_AspNetUsers_ApplicationUserId",
                        column: x => x.ApplicationUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_Donations_DonationId",
                        column: x => x.DonationId,
                        principalTable: "Donations",
                        principalColumn: "DonationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Items_ItemTypes_ItemTypeId",
                        column: x => x.ItemTypeId,
                        principalTable: "ItemTypes",
                        principalColumn: "ItemTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ItemTypes",
                columns: new[] { "ItemTypeId", "Title" },
                values: new object[,]
                {
                    { 1, "Electronics" },
                    { 2, "Furniture" },
                    { 3, "Clothing" }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "StatusId", "Title" },
                values: new object[,]
                {
                    { 1, "Pending Pick Up" },
                    { 2, "Picked Up" },
                    { 3, "Delivered" },
                    { 4, "Canceled" }
                });

            migrationBuilder.InsertData(
                table: "UserTypes",
                columns: new[] { "UserTypeId", "Title" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Employee" },
                    { 3, "Driver" },
                    { 4, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Address", "City", "FirstName", "LastName", "State", "UserPhoneNumber", "UserTypeId", "ZipCode" },
                values: new object[,]
                {
                    { "452830a2-a348-4e1b-94b7-8f3b3f8330c0", 0, "cc0ca400-37d7-4662-9a59-673a550945bb", "ApplicationUser", "madisonpeper@gmail.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEO1yM8HMWc0OKegIUzqGIyQtJy0867s+7D/V2ThbFOTryVciE35AHbxwnDHuql24Qg==", null, false, null, false, null, "1000 Nunya Business Dr", "Nashville", "Madison", "Peper", "Tennessee", "6158122717", 2, "37209" },
                    { "a14ec0d0-c55d-42f8-b607-81a8dcb71ffb", 0, "11a4703e-d865-4f30-b3b2-4b146c867cab", "ApplicationUser", "parker@kelley.com", false, false, null, null, null, "AQAAAAEAACcQAAAAEKHgNuZWi5P5MxGR4y1+LvdN+rYM6SSZHxtVlanr3a1J8tX3CuNphUhWNW7m8wmX+w==", null, false, null, false, null, "1509 Rainbow St", "Nashville", "Parker", "Kelley", "Tennessee", "6150987654", 2, "37212" },
                    { "cb60afa5-d6b7-4773-8f49-b9d31f55a454", 0, "e5dfca2c-3cdc-4f2d-8429-20449861b5a5", "ApplicationUser", "russell@nanney.com", false, false, null, null, null, "AQAAAAEAACcQAAAAENyMPhJ6urPK6kYN3Pg169k2pZ+dDXtPBnURU5YC9RHBQDrstxu3z3WuTwZ0F1I6fQ==", null, false, null, false, null, "2020 Nowhere Circle", "Nashville", "Russell", "Nanney", "Tennessee", "6152098318", 4, "37209" },
                    { "720a80ca-6217-4759-924a-58c8036bd0c2", 0, "2fd368e1-7a0a-46a2-8c4f-50e4642bbf76", "ApplicationUser", "stephanie@risch.com", false, false, null, null, null, "AQAAAAEAACcQAAAAED/dCDhRnAmpNk/88DetVRN0m/NfeDh85/8ks1+R1QbMqzGIOfUklKKBw4VzSH/YNQ==", null, false, null, false, null, "1060 OuttaMy Way", "Nashville", "Stephanie", "Risch", "Tennessee", "6151234567", 4, "37221" }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "DonationId", "DateCompleted", "DateCreated", "StatusId" },
                values: new object[,]
                {
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ApplicationUserId", "Description", "DonationId", "ItemTypeId", "Quantity", "Title", "Weight" },
                values: new object[] { 2, "cb60afa5-d6b7-4773-8f49-b9d31f55a454", "A 30\" Samsung TV, black, flat screen", 2, 1, 1, "30\" Samsung TV", 20 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ApplicationUserId", "Description", "DonationId", "ItemTypeId", "Quantity", "Title", "Weight" },
                values: new object[] { 1, "720a80ca-6217-4759-924a-58c8036bd0c2", "Size 7.5, never worn, brown leather booties", 1, 3, 1, "Brown Booties", 1 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "ApplicationUserId", "Description", "DonationId", "ItemTypeId", "Quantity", "Title", "Weight" },
                values: new object[] { 3, "720a80ca-6217-4759-924a-58c8036bd0c2", "A brown dresser with 4 drawers", 3, 2, 1, "Dresser", 60 });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_UserTypeId",
                table: "AspNetUsers",
                column: "UserTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_StatusId",
                table: "Donations",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ApplicationUserId",
                table: "Items",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_DonationId",
                table: "Items",
                column: "DonationId");

            migrationBuilder.CreateIndex(
                name: "IX_Items_ItemTypeId",
                table: "Items",
                column: "ItemTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_UserTypes_UserTypeId",
                table: "AspNetUsers",
                column: "UserTypeId",
                principalTable: "UserTypes",
                principalColumn: "UserTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_UserTypes_UserTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Items");

            migrationBuilder.DropTable(
                name: "UserTypes");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "ItemTypes");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_UserTypeId",
                table: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "452830a2-a348-4e1b-94b7-8f3b3f8330c0", "cc0ca400-37d7-4662-9a59-673a550945bb" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "720a80ca-6217-4759-924a-58c8036bd0c2", "2fd368e1-7a0a-46a2-8c4f-50e4642bbf76" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "a14ec0d0-c55d-42f8-b607-81a8dcb71ffb", "11a4703e-d865-4f30-b3b2-4b146c867cab" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "cb60afa5-d6b7-4773-8f49-b9d31f55a454", "e5dfca2c-3cdc-4f2d-8429-20449861b5a5" });

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "State",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserPhoneNumber",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "UserTypeId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Domain.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    PriceForOneKG = table.Column<decimal>(type: "numeric", nullable: false),
                    PriceForDelivery = table.Column<decimal>(type: "numeric", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RoleId = table.Column<int>(type: "integer", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    MiddleName = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CreatorId = table.Column<Guid>(type: "uuid", nullable: false),
                    DriverId = table.Column<Guid>(type: "uuid", nullable: true),
                    ProductTypeId = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Weight = table.Column<double>(type: "double precision", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    IsPayed = table.Column<bool>(type: "boolean", nullable: false),
                    From = table.Column<string>(type: "text", nullable: false),
                    To = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_ProductTypes_ProductTypeId",
                        column: x => x.ProductTypeId,
                        principalTable: "ProductTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Sessions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    Expires = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sessions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrackingDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    OrderId = table.Column<Guid>(type: "uuid", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: false),
                    Created = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Updated = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackingDetails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrackingDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ProductTypes",
                columns: new[] { "Id", "Created", "Name", "PriceForDelivery", "PriceForOneKG", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 20, 16, 56, 49, 67, DateTimeKind.Utc).AddTicks(7692), "Мебель", 300m, 100m, null },
                    { 2, new DateTime(2024, 5, 20, 16, 56, 49, 67, DateTimeKind.Utc).AddTicks(7808), "Электроника", 600m, 150m, null },
                    { 3, new DateTime(2024, 5, 20, 16, 56, 49, 67, DateTimeKind.Utc).AddTicks(7811), "Документы", 200m, 200m, null },
                    { 4, new DateTime(2024, 5, 20, 16, 56, 49, 67, DateTimeKind.Utc).AddTicks(7812), "Предметы личной гигиены", 300m, 100m, null },
                    { 5, new DateTime(2024, 5, 20, 16, 56, 49, 67, DateTimeKind.Utc).AddTicks(7814), "Драгоценности", 1000m, 150m, null }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Created", "Name", "Updated" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 5, 20, 16, 56, 49, 68, DateTimeKind.Utc).AddTicks(1296), "Guest", null },
                    { 2, new DateTime(2024, 5, 20, 16, 56, 49, 68, DateTimeKind.Utc).AddTicks(1322), "Driver", null },
                    { 3, new DateTime(2024, 5, 20, 16, 56, 49, 68, DateTimeKind.Utc).AddTicks(1324), "Operator", null },
                    { 4, new DateTime(2024, 5, 20, 16, 56, 49, 68, DateTimeKind.Utc).AddTicks(1325), "Admin", null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Created", "Email", "FirstName", "LastName", "MiddleName", "PasswordHash", "PhoneNumber", "RoleId", "Updated" },
                values: new object[,]
                {
                    { new Guid("3a64aa09-6f1f-4185-82b3-e0a3b4d85185"), new DateTime(2024, 5, 20, 16, 56, 49, 526, DateTimeKind.Utc).AddTicks(8033), "bulatadmin@example.com", "Булат", "Гиниятуллин", "Админ", "$2a$11$5RqPuLAsFd1vqxYbT9qE/.eOTS5TNshr/IUvj8fsUP4lTgDBdR3Fa", "+7199992224", 4, null },
                    { new Guid("4eeaeda0-bf8f-4245-9ca7-11cf6854edd0"), new DateTime(2024, 5, 20, 16, 56, 49, 366, DateTimeKind.Utc).AddTicks(4713), "bulatoperator@example.com", "Булат", "Гиниятуллин", "Оператор", "$2a$11$M7WaYRl1x.xUY4Q2nrfp5eIgoieB7S7idlTtaDkQCewVYv.atFRDK", "+7199992223", 3, null },
                    { new Guid("9385ebf5-29cb-4929-91e6-f6b893723f6d"), new DateTime(2024, 5, 20, 16, 56, 49, 69, DateTimeKind.Utc).AddTicks(525), "bulatguest@example.com", "Булат", "Гиниятуллин", "Гость", "$2a$11$N9F8zZ.JECqaeXbDyUzxcu5yKOa5o3E1AKDtnICTUGwroadhlRMwq", "+7199992222", 1, null },
                    { new Guid("a9446867-320b-4a77-be8e-77ccc0721fb7"), new DateTime(2024, 5, 20, 16, 56, 49, 217, DateTimeKind.Utc).AddTicks(506), "bulatdriver@example.com", "Булат", "Гиниятуллин", "Водитель", "$2a$11$Qlal9II98U.09lTj1Z0rKOCkh2dvqxgt1p3s6VrP7eFOO8TStCcpy", "+7199992221", 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreatorId",
                table: "Orders",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DriverId",
                table: "Orders",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductTypeId",
                table: "Orders",
                column: "ProductTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTypes_Name",
                table: "ProductTypes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_UserId",
                table: "Sessions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackingDetails_OrderId",
                table: "TrackingDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PhoneNumber",
                table: "Users",
                column: "PhoneNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sessions");

            migrationBuilder.DropTable(
                name: "TrackingDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ProductTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}

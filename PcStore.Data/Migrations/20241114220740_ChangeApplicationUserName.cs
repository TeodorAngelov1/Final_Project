using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PcStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangeApplicationUserName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_IdentityUser_SellerId1",
                table: "Products");

            migrationBuilder.DropTable(
                name: "IdentityUser");

            migrationBuilder.DropIndex(
                name: "IX_Products_SellerId1",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("1e623848-153e-4b28-83ba-0598885b0f5f"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("c0d5aee4-3623-422a-b332-f9cfea63e2f8"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("142a3c7f-2b0e-4517-befc-f2f51030cfaf"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("3197078e-6110-4d0f-8e04-58e3c8cc11bd"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("e34afc54-69f4-4aa8-88a7-f38d47c643c5"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("9eed6ba7-c7b9-4adc-b10b-7b2529dc47b7"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("bc612265-2635-4f0a-98eb-8159b4720fbd"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("d37b842a-2685-4671-a496-e9e9a18ad22a"));

            migrationBuilder.DropColumn(
                name: "SellerId1",
                table: "Products");

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("0ab3a3d9-223b-4937-bea6-8f55b329ad5d"), "Laptops" },
                    { new Guid("dfdc45c3-8780-40a1-bc07-5c052978ea13"), "Parts" }
                });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "LaptopDescription", "LaptopImageUrl", "LaptopName", "LaptopPrice" },
                values: new object[,]
                {
                    { new Guid("0cd0687c-84f1-4005-9b35-126aaa98cdbc"), "Best Laptop", null, "Lenovo", 3000m },
                    { new Guid("90118911-6e1f-49fe-917f-c9499714c265"), "Buy now", null, "Dell", 1800m },
                    { new Guid("9515938e-98b0-4d68-a4a6-39c5b7a27757"), "Nice Laptop", null, "HP", 1200m }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "PartBrand", "PartDescription", "PartImageUrl", "PartPrice" },
                values: new object[,]
                {
                    { new Guid("058b8819-b432-41f0-a1a0-57f16dfec794"), "Samsung", "RAM Memory", null, 200m },
                    { new Guid("989a0641-1e82-47e7-9b0d-56c2fc259e0d"), "Kingston", "SSD", null, 800m },
                    { new Guid("dbbce7c0-7ac6-4e0d-8861-b2595b1430d0"), "Seagete", "HDD", null, 100m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId",
                table: "Products",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_AspNetUsers_SellerId",
                table: "Products",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_AspNetUsers_SellerId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_SellerId",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("0ab3a3d9-223b-4937-bea6-8f55b329ad5d"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("dfdc45c3-8780-40a1-bc07-5c052978ea13"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("0cd0687c-84f1-4005-9b35-126aaa98cdbc"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("90118911-6e1f-49fe-917f-c9499714c265"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("9515938e-98b0-4d68-a4a6-39c5b7a27757"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("058b8819-b432-41f0-a1a0-57f16dfec794"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("989a0641-1e82-47e7-9b0d-56c2fc259e0d"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("dbbce7c0-7ac6-4e0d-8861-b2595b1430d0"));

            migrationBuilder.AddColumn<string>(
                name: "SellerId1",
                table: "Products",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "IdentityUser",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentityUser", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1e623848-153e-4b28-83ba-0598885b0f5f"), "Parts" },
                    { new Guid("c0d5aee4-3623-422a-b332-f9cfea63e2f8"), "Laptops" }
                });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "LaptopDescription", "LaptopImageUrl", "LaptopName", "LaptopPrice" },
                values: new object[,]
                {
                    { new Guid("142a3c7f-2b0e-4517-befc-f2f51030cfaf"), "Nice Laptop", null, "HP", 1200m },
                    { new Guid("3197078e-6110-4d0f-8e04-58e3c8cc11bd"), "Best Laptop", null, "Lenovo", 3000m },
                    { new Guid("e34afc54-69f4-4aa8-88a7-f38d47c643c5"), "Buy now", null, "Dell", 1800m }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "PartBrand", "PartDescription", "PartImageUrl", "PartPrice" },
                values: new object[,]
                {
                    { new Guid("9eed6ba7-c7b9-4adc-b10b-7b2529dc47b7"), "Kingston", "SSD", null, 800m },
                    { new Guid("bc612265-2635-4f0a-98eb-8159b4720fbd"), "Seagete", "HDD", null, 100m },
                    { new Guid("d37b842a-2685-4671-a496-e9e9a18ad22a"), "Samsung", "RAM Memory", null, 200m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SellerId1",
                table: "Products",
                column: "SellerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_IdentityUser_SellerId1",
                table: "Products",
                column: "SellerId1",
                principalTable: "IdentityUser",
                principalColumn: "Id");
        }
    }
}

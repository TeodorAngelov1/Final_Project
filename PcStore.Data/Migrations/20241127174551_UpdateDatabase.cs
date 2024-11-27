using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PcStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("47ff1e7f-9c7c-47f4-a336-2d7142107c57"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("59f06802-ff1a-469b-ba9e-ffbeae64d94f"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("bbc4fcb6-2b8c-4893-a499-716bcded6af7"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("1d1f27de-ae35-4e37-bdc9-812086174e55"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("a48f32d6-5906-4c2e-bba1-f2998a7622d9"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("e0d1f9a5-5fea-458e-b09c-a88ea78a5e37"));

            migrationBuilder.CreateTable(
                name: "Accessories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", maxLength: 300000, nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accessories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AccessoriesClients",
                columns: table => new
                {
                    AccessoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccessoriesClients", x => new { x.AccessoryId, x.ClientId });
                    table.ForeignKey(
                        name: "FK_AccessoriesClients_Accessories_AccessoryId",
                        column: x => x.AccessoryId,
                        principalTable: "Accessories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AccessoriesClients_AspNetUsers_ClientId",
                        column: x => x.ClientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Accessories",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { new Guid("1b514b75-158f-4902-9468-e88f573cc3db"), "JBL T100", "Buy now", null, false, 300m },
                    { new Guid("7da757de-928d-4689-b43c-832b0c956fab"), "BOSE Wireless Headphones", "Nice sound", null, false, 250m },
                    { new Guid("f5e7496e-32c8-4302-ae34-1e775162ba32"), "Sony Headphones", "The Best", null, false, 400m }
                });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { new Guid("2da545e5-6bca-4fac-88bd-615202a542c8"), "Lenovo", "Best Laptop", null, false, 3000m },
                    { new Guid("81280714-c39e-461b-9597-1d60f5922f0d"), "HP", "Nice Laptop", null, false, 1200m },
                    { new Guid("cf3ba0af-8661-4ea6-8d91-5967c605a82e"), "Dell", "Buy now", null, false, 1800m }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { new Guid("2f0c3ccc-e719-4d24-b8cb-4e1c6cb529f0"), "Seagete", "HDD", null, false, 100m },
                    { new Guid("33dfb343-7fd7-4042-abe0-8650797052a4"), "Kingston", "SSD", null, false, 800m },
                    { new Guid("c3b0cf01-c967-47d2-b7d7-6fc91b97085d"), "Samsung", "RAM Memory", null, false, 200m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccessoriesClients_ClientId",
                table: "AccessoriesClients",
                column: "ClientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccessoriesClients");

            migrationBuilder.DropTable(
                name: "Accessories");

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("2da545e5-6bca-4fac-88bd-615202a542c8"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("81280714-c39e-461b-9597-1d60f5922f0d"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("cf3ba0af-8661-4ea6-8d91-5967c605a82e"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("2f0c3ccc-e719-4d24-b8cb-4e1c6cb529f0"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("33dfb343-7fd7-4042-abe0-8650797052a4"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("c3b0cf01-c967-47d2-b7d7-6fc91b97085d"));

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { new Guid("47ff1e7f-9c7c-47f4-a336-2d7142107c57"), "Dell", "Buy now", null, false, 1800m },
                    { new Guid("59f06802-ff1a-469b-ba9e-ffbeae64d94f"), "Lenovo", "Best Laptop", null, false, 3000m },
                    { new Guid("bbc4fcb6-2b8c-4893-a499-716bcded6af7"), "HP", "Nice Laptop", null, false, 1200m }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { new Guid("1d1f27de-ae35-4e37-bdc9-812086174e55"), "Kingston", "SSD", null, false, 800m },
                    { new Guid("a48f32d6-5906-4c2e-bba1-f2998a7622d9"), "Seagete", "HDD", null, false, 100m },
                    { new Guid("e0d1f9a5-5fea-458e-b09c-a88ea78a5e37"), "Samsung", "RAM Memory", null, false, 200m }
                });
        }
    }
}

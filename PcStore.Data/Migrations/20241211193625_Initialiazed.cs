using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PcStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initialiazed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("1b514b75-158f-4902-9468-e88f573cc3db"));

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("7da757de-928d-4689-b43c-832b0c956fab"));

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("f5e7496e-32c8-4302-ae34-1e775162ba32"));

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
                table: "Accessories",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { new Guid("14a2a1d8-e1bd-4340-a4a0-ef45cbaef7e3"), "Sony Headphones", "The Best", null, false, 400m },
                    { new Guid("65cc0c24-6932-4163-a4a0-cc40647501e4"), "JBL T100", "Buy now", null, false, 300m },
                    { new Guid("78b52949-20df-4809-8573-a6ad3649fb92"), "BOSE Wireless Headphones", "Nice sound", null, false, 250m }
                });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { new Guid("32230c9a-3c02-42b3-85f0-06f06a42195e"), "Dell", "Buy now", null, false, 1800m },
                    { new Guid("bee2d2a7-ac54-454c-b7d7-e7d999b2ce3a"), "HP", "Nice Laptop", null, false, 1200m },
                    { new Guid("ebdaf20d-5064-409d-8dd4-d8a40a9b6d65"), "Lenovo", "Best Laptop", null, false, 3000m }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { new Guid("7c8badc3-d0d4-418b-a4de-f6bb7464055b"), "Kingston", "SSD", null, false, 800m },
                    { new Guid("d8c0745f-971a-4b6b-a77a-dbef75ae5c3a"), "Samsung", "RAM Memory", null, false, 200m },
                    { new Guid("e7a285b4-d2e2-4520-ab1f-0f85a817b2ee"), "Seagete", "HDD", null, false, 100m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("14a2a1d8-e1bd-4340-a4a0-ef45cbaef7e3"));

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("65cc0c24-6932-4163-a4a0-cc40647501e4"));

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("78b52949-20df-4809-8573-a6ad3649fb92"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("32230c9a-3c02-42b3-85f0-06f06a42195e"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("bee2d2a7-ac54-454c-b7d7-e7d999b2ce3a"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("ebdaf20d-5064-409d-8dd4-d8a40a9b6d65"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("7c8badc3-d0d4-418b-a4de-f6bb7464055b"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("d8c0745f-971a-4b6b-a77a-dbef75ae5c3a"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("e7a285b4-d2e2-4520-ab1f-0f85a817b2ee"));

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
        }
    }
}

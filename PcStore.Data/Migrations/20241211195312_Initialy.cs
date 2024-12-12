using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PcStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initialy : Migration
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
                    { new Guid("4a898425-b25a-485c-899d-417ecef39a62"), "BOSE Wireless Headphones", "Nice sound", null, false, 250m },
                    { new Guid("96ad1aba-f3f8-4489-b996-656fd622e028"), "JBL T100", "Buy now", null, false, 300m },
                    { new Guid("d9d7d4b9-542e-42e8-857a-62955eb61291"), "Sony Headphones", "The Best", null, false, 400m }
                });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { new Guid("0de55b13-0b37-4c1d-8fa2-d42a3ca94dc9"), "Lenovo", "Best Laptop", null, false, 3000m },
                    { new Guid("295bd679-1ad7-4c27-92c3-3429ce10dcc8"), "HP", "Nice Laptop", null, false, 1200m },
                    { new Guid("f014d01d-5ed5-4b55-b4fc-33a4125b0813"), "Dell", "Buy now", null, false, 1800m }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { new Guid("16c52554-bcda-4ef7-941a-c666c783bb0d"), "Seagete", "HDD", null, false, 100m },
                    { new Guid("31583a72-1afe-465e-b2a7-8ab166d8e591"), "Samsung", "RAM Memory", null, false, 200m },
                    { new Guid("52bdebad-f4d7-4759-95a1-ee40a0be4a0c"), "Kingston", "SSD", null, false, 800m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("4a898425-b25a-485c-899d-417ecef39a62"));

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("96ad1aba-f3f8-4489-b996-656fd622e028"));

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("d9d7d4b9-542e-42e8-857a-62955eb61291"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("0de55b13-0b37-4c1d-8fa2-d42a3ca94dc9"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("295bd679-1ad7-4c27-92c3-3429ce10dcc8"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("f014d01d-5ed5-4b55-b4fc-33a4125b0813"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("16c52554-bcda-4ef7-941a-c666c783bb0d"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("31583a72-1afe-465e-b2a7-8ab166d8e591"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("52bdebad-f4d7-4759-95a1-ee40a0be4a0c"));

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

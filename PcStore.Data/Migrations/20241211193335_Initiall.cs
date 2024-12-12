using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PcStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initiall : Migration
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
                    { new Guid("70b1f974-9ce5-428c-b17c-c82fa2485a5a"), "BOSE Wireless Headphones", "Nice sound", null, false, 250m },
                    { new Guid("99613231-fa32-4521-b178-29560938a273"), "JBL T100", "Buy now", null, false, 300m },
                    { new Guid("d02120ad-64d9-46b8-8515-583bea4bb27c"), "Sony Headphones", "The Best", null, false, 400m }
                });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { new Guid("6753d34c-6693-4e1d-a312-97e0f2541723"), "Dell", "Buy now", null, false, 1800m },
                    { new Guid("970c4e53-9fd6-430e-9146-4fecd8b86226"), "Lenovo", "Best Laptop", null, false, 3000m },
                    { new Guid("a39438f3-5d78-405e-bc2d-cf1fe7a6d237"), "HP", "Nice Laptop", null, false, 1200m }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { new Guid("201be707-b22f-4616-ad19-dcc04b51b963"), "Seagete", "HDD", null, false, 100m },
                    { new Guid("59468441-bb8f-40a9-bc44-ad208e1c2052"), "Samsung", "RAM Memory", null, false, 200m },
                    { new Guid("ca182e60-f3ef-43eb-86ca-b5b6f1444670"), "Kingston", "SSD", null, false, 800m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("70b1f974-9ce5-428c-b17c-c82fa2485a5a"));

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("99613231-fa32-4521-b178-29560938a273"));

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("d02120ad-64d9-46b8-8515-583bea4bb27c"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("6753d34c-6693-4e1d-a312-97e0f2541723"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("970c4e53-9fd6-430e-9146-4fecd8b86226"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("a39438f3-5d78-405e-bc2d-cf1fe7a6d237"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("201be707-b22f-4616-ad19-dcc04b51b963"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("59468441-bb8f-40a9-bc44-ad208e1c2052"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("ca182e60-f3ef-43eb-86ca-b5b6f1444670"));

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

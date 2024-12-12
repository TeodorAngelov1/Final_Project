using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PcStore.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initially : Migration
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
                    { new Guid("3a409c54-17c9-4660-96dc-0f487d61f955"), "Sony Headphones", "The Best", null, false, 400m },
                    { new Guid("6f75e842-02fb-4dd8-9393-981c6d1930ba"), "BOSE Wireless Headphones", "Nice sound", null, false, 250m },
                    { new Guid("b158d3a8-9651-4159-a767-e14436fffa5d"), "JBL T100", "Buy now", null, false, 300m }
                });

            migrationBuilder.InsertData(
                table: "Laptops",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { new Guid("748eaa35-c3d8-4f30-9be1-bfba91349ce5"), "Lenovo", "Best Laptop", null, false, 3000m },
                    { new Guid("a0e94a2a-8039-4905-a61d-da471dc1e69b"), "Dell", "Buy now", null, false, 1800m },
                    { new Guid("b1812d49-6df6-4419-8a4e-9de78b64856d"), "HP", "Nice Laptop", null, false, 1200m }
                });

            migrationBuilder.InsertData(
                table: "Parts",
                columns: new[] { "Id", "Brand", "Description", "ImageUrl", "IsDeleted", "Price" },
                values: new object[,]
                {
                    { new Guid("0638a383-d5e0-4492-9ab9-e44fd5cb9436"), "Seagete", "HDD", null, false, 100m },
                    { new Guid("d188e8fd-e06a-4836-8753-b8d36872e5a9"), "Samsung", "RAM Memory", null, false, 200m },
                    { new Guid("ec3cab5a-55bf-4f2b-b4b7-4f5ae744644f"), "Kingston", "SSD", null, false, 800m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("3a409c54-17c9-4660-96dc-0f487d61f955"));

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("6f75e842-02fb-4dd8-9393-981c6d1930ba"));

            migrationBuilder.DeleteData(
                table: "Accessories",
                keyColumn: "Id",
                keyValue: new Guid("b158d3a8-9651-4159-a767-e14436fffa5d"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("748eaa35-c3d8-4f30-9be1-bfba91349ce5"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("a0e94a2a-8039-4905-a61d-da471dc1e69b"));

            migrationBuilder.DeleteData(
                table: "Laptops",
                keyColumn: "Id",
                keyValue: new Guid("b1812d49-6df6-4419-8a4e-9de78b64856d"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("0638a383-d5e0-4492-9ab9-e44fd5cb9436"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("d188e8fd-e06a-4836-8753-b8d36872e5a9"));

            migrationBuilder.DeleteData(
                table: "Parts",
                keyColumn: "Id",
                keyValue: new Guid("ec3cab5a-55bf-4f2b-b4b7-4f5ae744644f"));

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

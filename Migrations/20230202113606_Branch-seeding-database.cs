using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KaravanCoffeeWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class Branchseedingdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "267ec1a4-c8be-45fe-a790-a109fe71531a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36e4d630-5b09-4e22-b15f-983f1b1c6e37");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7df9e8c0-f631-4f73-b2b1-7fd92c5e1321");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c63d9771-9ecd-4468-863a-83a4d07eb6b5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f807136-8b51-4525-9083-5b65ff1f7cd9", "879a0530-fb77-4262-8df8-6641c559bf42", "Customer", "CUSTOMER" },
                    { "35e074b4-1a9b-4ea8-a17e-06f6c3726a6d", "727e3c9b-8cfd-4d69-ab5e-95fa0b517a45", "Administrator", "ADMINISTRATOR" },
                    { "689258ad-c816-452b-874d-7a5f94e43c11", "4ce8e1b2-ebf4-4a72-8569-ddf83a37a1d8", "Branch Admin", "BRANCH ADMIN" },
                    { "db3b6e5b-09d9-4706-ae19-585370f8fac5", "97f1a198-aec1-46d7-9ad9-f09ee058d8d4", "System Admin", "SYSTEM ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "BranchId", "BranchAddress", "BranchName" },
                values: new object[,]
                {
                    { 1, "Megenagna, Bethelehem Plaza Gd.F", "Megenagna" },
                    { 2, "Bole Medhanialem Mall", "Bole" },
                    { 3, "Ayer Tena, 7 Story Building Gd.F", "Ayer Tena" },
                    { 4, "Tulu Dimtu, Amakor Building", "Tulu Dimtu" },
                    { 5, "Summit, Infront of Cambridge Academy", "Summit" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f807136-8b51-4525-9083-5b65ff1f7cd9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35e074b4-1a9b-4ea8-a17e-06f6c3726a6d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "689258ad-c816-452b-874d-7a5f94e43c11");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "db3b6e5b-09d9-4706-ae19-585370f8fac5");

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "BranchId",
                keyValue: 5);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "267ec1a4-c8be-45fe-a790-a109fe71531a", "5b1b7355-cd75-49ae-a070-d46076ac03ef", "System Admin", "SYSTEM ADMIN" },
                    { "36e4d630-5b09-4e22-b15f-983f1b1c6e37", "fd175ef8-9204-49e9-89b6-9d2160c8a48b", "Administrator", "ADMINISTRATOR" },
                    { "7df9e8c0-f631-4f73-b2b1-7fd92c5e1321", "045d927e-73ab-4c43-bfc1-91c06633a229", "Customer", "CUSTOMER" },
                    { "c63d9771-9ecd-4468-863a-83a4d07eb6b5", "112c50e5-3e72-469e-8583-c90672014983", "Branch Admin", "BRANCH ADMIN" }
                });
        }
    }
}

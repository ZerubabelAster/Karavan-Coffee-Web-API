using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KaravanCoffeeWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class GalleryAdded2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3aa7ab86-e2f1-41da-9447-b540b6c9eec8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "89a0da36-5793-4bc9-9ed6-27c3c99476a8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "af2320cb-3ccc-4224-8523-b57a209be48d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d87c18a1-d432-494b-bad3-8840353bc575");

            migrationBuilder.CreateTable(
                name: "Gallery",
                columns: table => new
                {
                    GalleryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UploadDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gallery", x => x.GalleryId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "091f67cb-1340-4d90-9258-36caab10c1f3", "3c4d809c-1366-42de-9995-507933792732", "Customer", "CUSTOMER" },
                    { "ae35553f-e551-4916-b858-9b3ea1a9ae52", "f8efa564-81b4-456d-a1a7-0e2151073890", "System Admin", "SYSTEM ADMIN" },
                    { "bd6b36df-7c12-4a04-a988-bc3259a3899e", "0ddd249a-0f29-47a2-8458-d861d86ef5d2", "Administrator", "ADMINISTRATOR" },
                    { "d99c1efa-8f99-413e-803c-97aff3be4009", "b05b3715-194a-4fd1-aafb-7e7acef462ef", "Branch Admin", "BRANCH ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gallery");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "091f67cb-1340-4d90-9258-36caab10c1f3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae35553f-e551-4916-b858-9b3ea1a9ae52");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd6b36df-7c12-4a04-a988-bc3259a3899e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d99c1efa-8f99-413e-803c-97aff3be4009");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3aa7ab86-e2f1-41da-9447-b540b6c9eec8", "1878a185-7378-4d3b-b7f5-c8b963551ead", "Branch Admin", "BRANCH ADMIN" },
                    { "89a0da36-5793-4bc9-9ed6-27c3c99476a8", "6e1c6f73-8155-4fc2-ab3b-1bbe80a8ed4c", "Customer", "CUSTOMER" },
                    { "af2320cb-3ccc-4224-8523-b57a209be48d", "ae6df633-6cf6-4352-9b4e-a6fb4656697a", "Administrator", "ADMINISTRATOR" },
                    { "d87c18a1-d432-494b-bad3-8840353bc575", "18a3ea67-2bcb-431a-9837-e89917c6989b", "System Admin", "SYSTEM ADMIN" }
                });
        }
    }
}

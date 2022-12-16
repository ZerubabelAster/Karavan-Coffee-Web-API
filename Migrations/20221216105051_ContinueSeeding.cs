using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KaravanCoffeeWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class ContinueSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3221126e-0aca-4991-8c3e-091ec1df29bb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3fda2f02-f303-41c2-a285-b3f7e9ef7a21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c2ee27a-f157-4758-a8ec-1ef45b801082");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "75614951-0742-4ee0-b937-bb56e4158a79");

            migrationBuilder.DropColumn(
                name: "RequireExtra",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "MainIngredients",
                table: "Products",
                newName: "Ingredients");

            migrationBuilder.AddColumn<DateTime>(
                name: "EPT",
                table: "Products",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Extras",
                table: "Products",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "39c28bc2-b7e5-44a6-8e9c-b9a4868c4859", "df1f247c-62ae-4aa2-9b21-6d80b363f7d8", "System Admin", "SYSTEM ADMIN" },
                    { "5abe3177-f509-4584-842c-2bd7d91f6cd3", "6f8f26e7-3e18-4fc0-9b1c-34646286cf05", "Branch Admin", "BRANCH ADMIN" },
                    { "8c771db2-3931-41e6-b475-25d14790c7e5", "3e3a627c-6034-4d4f-abe3-b5258a1f8670", "Administrator", "ADMINISTRATOR" },
                    { "9bb8c73f-ecb9-407d-81bb-e562f6abfc8e", "a5275699-b14f-44f0-bf91-7f804cc62c9e", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                columns: new[] { "EPT", "Extras" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                columns: new[] { "EPT", "Extras" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                columns: new[] { "EPT", "Extras" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                columns: new[] { "EPT", "Extras" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                columns: new[] { "EPT", "Extras" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                columns: new[] { "EPT", "Extras" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                columns: new[] { "EPT", "Extras" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                columns: new[] { "EPT", "Extras" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                columns: new[] { "EPT", "Extras" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                columns: new[] { "EPT", "Extras" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                columns: new[] { "EPT", "Extras" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12,
                columns: new[] { "EPT", "Extras" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13,
                columns: new[] { "EPT", "Extras" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Active", "Discount", "EPT", "Extras", "ImagePath", "Ingredients", "ProductCategory", "ProductCode", "ProductDescription", "ProductName", "ProductPoint", "ProductSubCategory", "Rating", "TotalOrdered", "UnitPrice" },
                values: new object[,]
                {
                    { 14, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000014", "", "ACACIA DRY RED WINE", 0, "BOTTLED WINE", 5.0, 0, 480.0 },
                    { 15, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000015", "", "ACACIA DRY WHITE WINE", 0, "BOTTLED WINE", 5.0, 0, 480.0 },
                    { 16, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000016", "", "ACACIA ROSE WINE", 0, "BOTTLED WINE", 5.0, 0, 480.0 },
                    { 17, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000017", "", "ACACIA SWEET RED WINE", 0, "BOTTLED WINE", 5.0, 0, 480.0 },
                    { 18, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000018", "", "ACACIA SWEET WHITE WINE", 0, "BOTTLED WINE", 5.0, 0, 480.0 },
                    { 19, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000019", "", "AWASH TEKESHINO", 0, "BOTTLED WINE", 5.0, 0, 350.0 },
                    { 20, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000020", "", "AWASH WINE", 0, "BOTTLED WINE", 5.0, 0, 250.0 },
                    { 21, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000021", "", "AXUMIT RED WINE", 0, "BOTTLED WINE", 5.0, 0, 350.0 },
                    { 22, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000022", "", "HENDEKE RED WINE", 0, "BOTTLED WINE", 5.0, 0, 250.0 },
                    { 23, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000023", "", "RIFT VALLEY MERLOT", 0, "BOTTLED WINE", 5.0, 0, 480.0 },
                    { 24, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000024", "", "RIFT VALLEY CHARDONNAY", 0, "BOTTLED WINE", 5.0, 0, 480.0 },
                    { 25, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000025", "", "SHEBELE WHITE WINE", 0, "BOTTLED WINE", 5.0, 0, 250.0 },
                    { 26, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000026", "", "TEJ 1 LITER", 0, "BOTTLED WINE", 5.0, 0, 280.0 },
                    { 27, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000027", "", "ST.GEORGE JAMBO DRAFT", 0, "DRAFT BEER", 5.0, 0, 34.0 },
                    { 28, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000028", "", "ST.GEORGE SINGLE DRAFT", 0, "DRAFT BEER", 5.0, 0, 23.0 },
                    { 29, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000029", "", "WALIA JAMBO DRAFT", 0, "DRAFT BEER", 5.0, 0, 34.0 },
                    { 30, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000030", "", "WALIA SINGLE DRAFT", 0, "DRAFT BEER", 5.0, 0, 23.0 },
                    { 31, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000031", "", "ABSOLUTE VODKA HALF BOTTLE(MEZO)", 0, "LIQUOR", 5.0, 0, 1200.0 },
                    { 32, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000032", "", "BLACK LABEL DOUBLE SHOT", 0, "LIQUOR", 5.0, 0, 280.0 },
                    { 33, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000033", "", "CHIVAS REGAL DOUBLE SHOT", 0, "LIQUOR", 5.0, 0, 150.0 },
                    { 34, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000034", "", "JACK  DANIELS HALF BOTTLE(MEZO)", 0, "LIQUOR", 5.0, 0, 4800.0 },
                    { 35, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000035", "", "OX CAFE", 0, "LIQUOR", 5.0, 0, 4200.0 },
                    { 36, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000036", "", "RED LABEL DOUBLE SHAT", 0, "LIQUOR", 5.0, 0, 150.0 },
                    { 37, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000037", "", "SPECIAL GOLD LABEL WHISKY", 0, "LIQUOR", 5.0, 0, 5000.0 },
                    { 38, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000038", "", "STOLICHINYA DOUBLE SHAT", 0, "LIQUOR", 5.0, 0, 165.0 },
                    { 39, false, 0.0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "", "", "", "ALCOHOLIC BEVERAGES", "PML-000039", "", "WHITE HORSE DOUBLE SHAT", 0, "LIQUOR", 5.0, 0, 75.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "39c28bc2-b7e5-44a6-8e9c-b9a4868c4859");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5abe3177-f509-4584-842c-2bd7d91f6cd3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8c771db2-3931-41e6-b475-25d14790c7e5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bb8c73f-ecb9-407d-81bb-e562f6abfc8e");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 39);

            migrationBuilder.DropColumn(
                name: "EPT",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Extras",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "Ingredients",
                table: "Products",
                newName: "MainIngredients");

            migrationBuilder.AddColumn<bool>(
                name: "RequireExtra",
                table: "Products",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3221126e-0aca-4991-8c3e-091ec1df29bb", "5ac39dc9-1fb8-46eb-801d-8ccc19948ee0", "Branch Admin", "BRANCH ADMIN" },
                    { "3fda2f02-f303-41c2-a285-b3f7e9ef7a21", "8127e067-83ae-48f4-be3f-07bee1ed5d15", "System Admin", "SYSTEM ADMIN" },
                    { "5c2ee27a-f157-4758-a8ec-1ef45b801082", "15907dc3-b738-41c5-9fae-35b302136d9b", "Administrator", "ADMINISTRATOR" },
                    { "75614951-0742-4ee0-b937-bb56e4158a79", "5ed14b50-936e-4cb1-bc99-8845545d567d", "Customer", "CUSTOMER" }
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "RequireExtra",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "RequireExtra",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "RequireExtra",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 4,
                column: "RequireExtra",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 5,
                column: "RequireExtra",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 6,
                column: "RequireExtra",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 7,
                column: "RequireExtra",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 8,
                column: "RequireExtra",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 9,
                column: "RequireExtra",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 10,
                column: "RequireExtra",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 11,
                column: "RequireExtra",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 12,
                column: "RequireExtra",
                value: false);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 13,
                column: "RequireExtra",
                value: false);
        }
    }
}

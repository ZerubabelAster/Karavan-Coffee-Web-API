using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KaravanCoffeeWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class GalleryAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    FirstName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LastName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Gender = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedUserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NormalizedEmail = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    EmailConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    PasswordHash = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SecurityStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ConcurrencyStamp = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumberConfirmed = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetime", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Branches",
                columns: table => new
                {
                    BranchId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    BranchName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BranchAddress = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductCategory = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductSubCategory = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnitPrice = table.Column<double>(type: "double", nullable: false),
                    Ingredients = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Extras = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Orderable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Discount = table.Column<double>(type: "double", nullable: false),
                    ProductPoint = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "double", nullable: false),
                    TotalOrdered = table.Column<int>(type: "int", nullable: false),
                    EPT = table.Column<TimeOnly>(type: "time(0)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClaimValue = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderKey = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProviderDisplayName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LoginProvider = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Name = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Value = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    OrderType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentMode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderStatus = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    PickupDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalPrice = table.Column<double>(type: "double", nullable: false),
                    RedeemedPoints = table.Column<int>(type: "int", nullable: false),
                    ApprovedBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeliveredBy = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Void = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(95)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductAvailability",
                columns: table => new
                {
                    ProductAvailabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    MinThreshold = table.Column<int>(type: "int", nullable: false),
                    MaxThreshold = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAvailability", x => x.ProductAvailabilityId);
                    table.ForeignKey(
                        name: "FK_ProductAvailability_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAvailability_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    OrderDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ExtrasRequested = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RemovalRequested = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnitPrice = table.Column<double>(type: "double", nullable: false),
                    ExtraCharge = table.Column<double>(type: "double", nullable: false),
                    Discount = table.Column<double>(type: "double", nullable: false),
                    SubTotal = table.Column<double>(type: "double", nullable: false),
                    Rating = table.Column<double>(type: "double", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.OrderDetailId);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "LoyalityDetail",
                columns: table => new
                {
                    LoyalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    LoyalityPoint = table.Column<int>(type: "int", nullable: false),
                    OrderDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    OrderDetailId = table.Column<int>(type: "int", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoyalityDetail", x => x.LoyalityId);
                    table.ForeignKey(
                        name: "FK_LoyalityDetail_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoyalityDetail_OrderDetails_OrderDetailId",
                        column: x => x.OrderDetailId,
                        principalTable: "OrderDetails",
                        principalColumn: "OrderDetailId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Active", "Discount", "EPT", "Extras", "ImagePath", "Ingredients", "Orderable", "ProductCategory", "ProductCode", "ProductDescription", "ProductName", "ProductPoint", "ProductSubCategory", "Rating", "TotalOrdered", "UnitPrice" },
                values: new object[,]
                {
                    { 1, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000001", "", "ANBESA BEER", 0, "BOTTLED BEER", 5.0, 0, 35.0 },
                    { 2, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000002", "", "ARADA BEER", 0, "BOTTLED BEER", 5.0, 0, 45.0 },
                    { 3, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000003", "", "BEDELE BEER BIG", 0, "BOTTLED BEER", 5.0, 0, 45.0 },
                    { 4, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000004", "", "BEDELE BEER SMALL", 0, "BOTTLED BEER", 5.0, 0, 43.0 },
                    { 5, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000005", "", "CASTLE BEER", 0, "BOTTLED BEER", 5.0, 0, 43.0 },
                    { 6, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000006", "", "DASHEN BEER", 0, "BOTTLED BEER", 5.0, 0, 43.0 },
                    { 7, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000007", "", "HABESHA BEER", 0, "BOTTLED BEER", 5.0, 0, 43.0 },
                    { 8, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000008", "", "HARAR BEER", 0, "BOTTLED BEER", 5.0, 0, 43.0 },
                    { 9, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000009", "", "HEINEKEN BEER", 0, "BOTTLED BEER", 5.0, 0, 33.0 },
                    { 10, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000010", "", "MALTA", 0, "BOTTLED BEER", 5.0, 0, 43.0 },
                    { 11, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000011", "", "SENQ BEER", 0, "BOTTLED BEER", 5.0, 0, 43.0 },
                    { 12, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000012", "", "ST GEORGE BEER", 0, "BOTTLED BEER", 5.0, 0, 43.0 },
                    { 13, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000013", "", "WALIA BEER", 0, "BOTTLED BEER", 5.0, 0, 43.0 },
                    { 14, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000014", "", "ACACIA DRY RED WINE", 0, "BOTTLED WINE", 5.0, 0, 480.0 },
                    { 15, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000015", "", "ACACIA DRY WHITE WINE", 0, "BOTTLED WINE", 5.0, 0, 480.0 },
                    { 16, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000016", "", "ACACIA ROSE WINE", 0, "BOTTLED WINE", 5.0, 0, 480.0 },
                    { 17, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000017", "", "ACACIA SWEET RED WINE", 0, "BOTTLED WINE", 5.0, 0, 480.0 },
                    { 18, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000018", "", "ACACIA SWEET WHITE WINE", 0, "BOTTLED WINE", 5.0, 0, 480.0 },
                    { 19, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000019", "", "AWASH TEKESHINO", 0, "BOTTLED WINE", 5.0, 0, 350.0 },
                    { 20, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000020", "", "AWASH WINE", 0, "BOTTLED WINE", 5.0, 0, 250.0 },
                    { 21, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000021", "", "AXUMIT RED WINE", 0, "BOTTLED WINE", 5.0, 0, 350.0 },
                    { 22, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000022", "", "HENDEKE RED WINE", 0, "BOTTLED WINE", 5.0, 0, 250.0 },
                    { 23, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000023", "", "RIFT VALLEY MERLOT", 0, "BOTTLED WINE", 5.0, 0, 480.0 },
                    { 24, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000024", "", "RIFT VALLEY CHARDONNAY", 0, "BOTTLED WINE", 5.0, 0, 480.0 },
                    { 25, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000025", "", "SHEBELE WHITE WINE", 0, "BOTTLED WINE", 5.0, 0, 250.0 },
                    { 26, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000026", "", "TEJ 1 LITER", 0, "BOTTLED WINE", 5.0, 0, 280.0 },
                    { 27, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000027", "", "ST.GEORGE JAMBO DRAFT", 0, "DRAFT BEER", 5.0, 0, 34.0 },
                    { 28, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000028", "", "ST.GEORGE SINGLE DRAFT", 0, "DRAFT BEER", 5.0, 0, 23.0 },
                    { 29, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000029", "", "WALIA JAMBO DRAFT", 0, "DRAFT BEER", 5.0, 0, 34.0 },
                    { 30, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000030", "", "WALIA SINGLE DRAFT", 0, "DRAFT BEER", 5.0, 0, 23.0 },
                    { 31, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000031", "", "ABSOLUTE VODKA HALF BOTTLE(MEZO)", 0, "LIQUOR", 5.0, 0, 1200.0 },
                    { 32, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000032", "", "BLACK LABEL DOUBLE SHOT", 0, "LIQUOR", 5.0, 0, 280.0 },
                    { 33, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000033", "", "CHIVAS REGAL DOUBLE SHOT", 0, "LIQUOR", 5.0, 0, 150.0 },
                    { 34, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000034", "", "JACK  DANIELS HALF BOTTLE(MEZO)", 0, "LIQUOR", 5.0, 0, 4800.0 },
                    { 35, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000035", "", "OX CAFE", 0, "LIQUOR", 5.0, 0, 4200.0 },
                    { 36, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000036", "", "RED LABEL DOUBLE SHAT", 0, "LIQUOR", 5.0, 0, 150.0 },
                    { 37, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000037", "", "SPECIAL GOLD LABEL WHISKY", 0, "LIQUOR", 5.0, 0, 5000.0 },
                    { 38, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000038", "", "STOLICHINYA DOUBLE SHAT", 0, "LIQUOR", 5.0, 0, 165.0 },
                    { 39, false, 0.0, new TimeOnly(0, 0, 0), "", "", "", false, "ALCOHOLIC BEVERAGES", "PML-000039", "", "WHITE HORSE DOUBLE SHAT", 0, "LIQUOR", 5.0, 0, 75.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LoyalityDetail_BranchId",
                table: "LoyalityDetail",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_LoyalityDetail_OrderDetailId",
                table: "LoyalityDetail",
                column: "OrderDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_BranchId",
                table: "Orders",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAvailability_BranchId",
                table: "ProductAvailability",
                column: "BranchId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAvailability_ProductId",
                table: "ProductAvailability",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "LoyalityDetail");

            migrationBuilder.DropTable(
                name: "ProductAvailability");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Branches");
        }
    }
}

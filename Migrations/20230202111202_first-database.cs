using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KaravanCoffeeWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class firstdatabase : Migration
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
                    FullName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BirthDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    Gender = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "longtext", nullable: true)
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
                    BranchName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    BranchAddress = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Branches", x => x.BranchId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Galleries",
                columns: table => new
                {
                    GalleryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Galleries", x => x.GalleryId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IngredientCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IngredientName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IngredientDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnitPrice = table.Column<double>(type: "double", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Discount = table.Column<double>(type: "double", nullable: false),
                    ImagePath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.IngredientId);
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
                    OrderType = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PaymentMode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderStatus = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    PickupDateTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalPrice = table.Column<double>(type: "double", nullable: false),
                    RedeemedPoints = table.Column<int>(type: "int", nullable: false),
                    ApprovedBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeliveredBy = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Void = table.Column<byte>(type: "tinyint unsigned", nullable: false),
                    BranchId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "varchar(95)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_Branches_BranchId",
                        column: x => x.BranchId,
                        principalTable: "Branches",
                        principalColumn: "BranchId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "SubCategories",
                columns: table => new
                {
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SubCategoryName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubCategoryDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubCategories", x => x.SubCategoryId);
                    table.ForeignKey(
                        name: "FK_SubCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ProductCode = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ProductDescription = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UnitPrice = table.Column<double>(type: "double", nullable: false),
                    Active = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Discount = table.Column<double>(type: "double", nullable: false),
                    ProductPoint = table.Column<int>(type: "int", nullable: false),
                    Rating = table.Column<double>(type: "double", nullable: false),
                    AverageQueueDay = table.Column<int>(type: "int", nullable: false),
                    AverageQueueTime = table.Column<TimeOnly>(type: "time(0)", nullable: false),
                    Orderable = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Tag = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImagePath = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    SubCategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_SubCategories_SubCategoryId",
                        column: x => x.SubCategoryId,
                        principalTable: "SubCategories",
                        principalColumn: "SubCategoryId",
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
                    UnitPrice = table.Column<double>(type: "double", nullable: false),
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
                    { "267ec1a4-c8be-45fe-a790-a109fe71531a", "5b1b7355-cd75-49ae-a070-d46076ac03ef", "System Admin", "SYSTEM ADMIN" },
                    { "36e4d630-5b09-4e22-b15f-983f1b1c6e37", "fd175ef8-9204-49e9-89b6-9d2160c8a48b", "Administrator", "ADMINISTRATOR" },
                    { "7df9e8c0-f631-4f73-b2b1-7fd92c5e1321", "045d927e-73ab-4c43-bfc1-91c06633a229", "Customer", "CUSTOMER" },
                    { "c63d9771-9ecd-4468-863a-83a4d07eb6b5", "112c50e5-3e72-469e-8583-c90672014983", "Branch Admin", "BRANCH ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CategoryDescription", "CategoryName", "ImagePath" },
                values: new object[,]
                {
                    { 1, "", "ALCOHOLIC BEVERAGES", "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg" },
                    { 2, "", "BAKERY", "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg" },
                    { 3, "", "CAKE", "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg" },
                    { 4, "", "COLD BEVERAGES", "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg" },
                    { 5, "", "FAST FOOD", "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg" },
                    { 6, "", "FRUIT BEVERAGES", "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg" },
                    { 7, "", "HOT BEVERAGES", "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg" },
                    { 8, "", "ICE CREAM", "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg" },
                    { 9, "", "SALES SUPPORT", "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg" }
                });

            migrationBuilder.InsertData(
                table: "SubCategories",
                columns: new[] { "SubCategoryId", "CategoryId", "ImagePath", "SubCategoryDescription", "SubCategoryName" },
                values: new object[,]
                {
                    { 1, 1, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "BOTTLED BEER" },
                    { 2, 1, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "BOTTLED WINE" },
                    { 3, 1, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "DRAFT BEER" },
                    { 4, 1, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "LIQUOR" },
                    { 5, 2, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "BISCUITS" },
                    { 6, 2, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "BREAD" },
                    { 7, 2, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "COOKIES" },
                    { 8, 2, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "PANETTONE" },
                    { 9, 2, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "TARTS" },
                    { 10, 3, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "CREAM CAKE" },
                    { 11, 3, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "DRY CAKE" },
                    { 12, 3, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "EVENT TORTA" },
                    { 13, 3, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "NOVELITY TORTA" },
                    { 14, 3, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "TORTA" },
                    { 15, 3, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "WEDDING CAKE" },
                    { 16, 4, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "MINERAL WATER" },
                    { 17, 4, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "SOFT DRINK" },
                    { 18, 4, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "WATER" },
                    { 19, 5, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "BREAKFAST" },
                    { 20, 5, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "BURGER" },
                    { 21, 5, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "FISH" },
                    { 22, 5, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "MINERAL WATER" },
                    { 23, 5, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "HABESHA" },
                    { 24, 5, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "PIZZA & PASTA" },
                    { 25, 5, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "SANDWICH & WRAPS" },
                    { 26, 5, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "SIDES & SNACK" },
                    { 27, 6, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "JUICE" },
                    { 28, 7, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "COFFEE" },
                    { 29, 8, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "ICE CREAM PUNCH" },
                    { 30, 8, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "ICE CREAM SCOOP" },
                    { 31, 8, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "ICE CREAM TOPPING" },
                    { 32, 8, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "MILK SHAKE" },
                    { 33, 9, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", "", "PACKAGING" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Active", "AverageQueueDay", "AverageQueueTime", "CategoryId", "Discount", "ImagePath", "Orderable", "ProductCode", "ProductDescription", "ProductName", "ProductPoint", "Rating", "SubCategoryId", "Tag", "UnitPrice" },
                values: new object[,]
                {
                    { 1, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000001", "", "ANBESA BEER", 0, 5.0, 1, "", 35.0 },
                    { 2, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000002", "", "ARADA BEER", 0, 5.0, 1, "", 45.0 },
                    { 3, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000003", "", "BEDELE BEER BIG", 0, 5.0, 1, "", 45.0 },
                    { 4, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000004", "", "BEDELE BEER SMALL", 0, 5.0, 1, "", 43.0 },
                    { 5, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000005", "", "CASTLE BEER", 0, 5.0, 1, "", 43.0 },
                    { 6, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000006", "", "DASHEN BEER", 0, 5.0, 1, "", 43.0 },
                    { 7, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000007", "", "HABESHA BEER", 0, 5.0, 1, "", 43.0 },
                    { 8, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000008", "", "HARAR BEER", 0, 5.0, 1, "", 43.0 },
                    { 9, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000009", "", "HEINEKEN BEER", 0, 5.0, 1, "", 33.0 },
                    { 10, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000010", "", "MALTA", 0, 5.0, 1, "", 43.0 },
                    { 11, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000011", "", "SENQ BEER", 0, 5.0, 1, "", 43.0 },
                    { 12, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000012", "", "ST GEORGE BEER", 0, 5.0, 1, "", 43.0 },
                    { 13, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000013", "", "WALIA BEER", 0, 5.0, 1, "", 43.0 },
                    { 14, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000014", "", "ACACIA DRY RED WINE", 0, 5.0, 2, "", 480.0 },
                    { 15, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000015", "", "ACACIA DRY WHITE WINE", 0, 5.0, 2, "", 480.0 },
                    { 16, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000016", "", "ACACIA ROSE WINE", 0, 5.0, 2, "", 480.0 },
                    { 17, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000017", "", "ACACIA SWEET RED WINE", 0, 5.0, 2, "", 480.0 },
                    { 18, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000018", "", "ACACIA SWEET WHITE WINE", 0, 5.0, 2, "", 480.0 },
                    { 19, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000019", "", "AWASH TEKESHINO", 0, 5.0, 2, "", 350.0 },
                    { 20, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000020", "", "AWASH WINE", 0, 5.0, 2, "", 250.0 },
                    { 21, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000021", "", "AXUMIT RED WINE", 0, 5.0, 2, "", 350.0 },
                    { 22, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000022", "", "HENDEKE RED WINE", 0, 5.0, 2, "", 250.0 },
                    { 23, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000023", "", "RIFT VALLEY MERLOT", 0, 5.0, 2, "", 480.0 },
                    { 24, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000024", "", "RIFT VALLEY CHARDONNAY", 0, 5.0, 2, "", 480.0 },
                    { 25, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000025", "", "SHEBELE WHITE WINE", 0, 5.0, 2, "", 250.0 },
                    { 26, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000026", "", "TEJ 1 LITER", 0, 5.0, 2, "", 280.0 },
                    { 27, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000027", "", "ST.GEORGE JAMBO DRAFT", 0, 5.0, 3, "", 34.0 },
                    { 28, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000028", "", "ST.GEORGE SINGLE DRAFT", 0, 5.0, 3, "", 23.0 },
                    { 29, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000029", "", "WALIA JAMBO DRAFT", 0, 5.0, 3, "", 34.0 },
                    { 30, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000030", "", "WALIA SINGLE DRAFT", 0, 5.0, 3, "", 23.0 },
                    { 31, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000031", "", "ABSOLUTE VODKA HALF BOTTLE(MEZO)", 0, 5.0, 4, "", 1200.0 },
                    { 32, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000032", "", "BLACK LABEL DOUBLE SHOT", 0, 5.0, 4, "", 280.0 },
                    { 33, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000033", "", "CHIVAS REGAL DOUBLE SHOT", 0, 5.0, 4, "", 150.0 },
                    { 34, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000034", "", "JACK  DANIELS HALF BOTTLE(MEZO)", 0, 5.0, 4, "", 4800.0 },
                    { 35, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000035", "", "OX CAFE", 0, 5.0, 4, "", 4200.0 },
                    { 36, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000036", "", "RED LABEL DOUBLE SHAT", 0, 5.0, 4, "", 150.0 },
                    { 37, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000037", "", "SPECIAL GOLD LABEL WHISKY", 0, 5.0, 4, "", 5000.0 },
                    { 38, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000038", "", "STOLICHINYA DOUBLE SHAT", 0, 5.0, 4, "", 165.0 },
                    { 39, false, 0, new TimeOnly(0, 0, 0), 1, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000039", "", "WHITE HORSE DOUBLE SHAT", 0, 5.0, 4, "", 75.0 },
                    { 40, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000040", "", "CHOCOLATE CHIP BISCUIT", 0, 5.0, 5, "", 75.0 },
                    { 41, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000041", "", "OATS BISCUTE", 0, 5.0, 5, "", 80.0 },
                    { 42, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000042", "", "VANILLA BISCUIT", 0, 5.0, 5, "", 60.0 },
                    { 43, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000043", "", "200GM BREAD", 0, 5.0, 6, "", 8.0 },
                    { 44, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000044", "", "2KG HABESHA BREAD", 0, 5.0, 6, "", 175.0 },
                    { 45, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000045", "", "300GM BERAD", 0, 5.0, 6, "", 15.0 },
                    { 46, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000046", "", "4KG HABESHA BREAD", 0, 5.0, 6, "", 350.0 },
                    { 47, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000047", "", "500GM BERAD", 0, 5.0, 6, "", 20.0 },
                    { 48, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000048", "", "NORMAL BREAD", 0, 5.0, 6, "", 5.0 },
                    { 49, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000049", "", "SLICE BREAD", 0, 5.0, 6, "", 30.0 },
                    { 50, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000050", "", "1KG COOKIES", 0, 5.0, 7, "", 400.0 },
                    { 51, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000051", "", "1/2KG COOKIES", 0, 5.0, 7, "", 200.0 },
                    { 52, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000052", "", "1/2KG PANETTONE", 0, 5.0, 8, "", 200.0 },
                    { 53, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000053", "", "APPLE PIE", 0, 5.0, 9, "", 95.0 },
                    { 54, false, 0, new TimeOnly(0, 0, 0), 2, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000054", "", "CHOCOLATE TART", 0, 5.0, 9, "", 85.0 },
                    { 55, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000055", "", "BLACK FOREST CAKE", 0, 5.0, 10, "", 80.0 },
                    { 56, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000056", "", "BLUE BERRY CAKE", 0, 5.0, 10, "", 100.0 },
                    { 57, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000057", "", "BOXEGNA", 0, 5.0, 10, "", 90.0 },
                    { 58, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000058", "", "BRONZE CAKE", 0, 5.0, 10, "", 105.0 },
                    { 59, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000059", "", "CARAMEL CAKE", 0, 5.0, 10, "", 95.0 },
                    { 60, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000060", "", "CHOCOLATE BUTTER CAKE", 0, 5.0, 10, "", 105.0 },
                    { 61, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000061", "", "CHOCOLATE TRUFFLE CAKE", 0, 5.0, 10, "", 105.0 },
                    { 62, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000062", "", "CUP CAKE WITH CREAM", 0, 5.0, 10, "", 90.0 },
                    { 63, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000063", "", "CUP CAKE WITH FONDANT", 0, 5.0, 10, "", 120.0 },
                    { 64, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000064", "", "DESSERT CUPS", 0, 5.0, 10, "", 70.0 },
                    { 65, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000065", "", "DOUBLE CHOCOLATE", 0, 5.0, 10, "", 107.0 },
                    { 66, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000066", "", "EIFFEL TOWER BOXEGNA", 0, 5.0, 10, "", 970.0 },
                    { 67, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000067", "", "FASTING CREAM CAKE", 0, 5.0, 10, "", 80.0 },
                    { 68, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000068", "", "HONEY CAKE", 0, 5.0, 10, "", 105.0 },
                    { 69, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000069", "", "KARAVAN PARTY MIX", 0, 5.0, 10, "", 450.0 },
                    { 70, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000070", "", "LEMON CAKE", 0, 5.0, 10, "", 105.0 },
                    { 71, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000071", "", "MILLEFEUILLE", 0, 5.0, 10, "", 80.0 },
                    { 72, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000072", "", "OPERA CAKE", 0, 5.0, 10, "", 109.0 },
                    { 73, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000073", "", "ORANGE CAKE", 0, 5.0, 10, "", 100.0 },
                    { 74, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000074", "", "OREO CAKE", 0, 5.0, 10, "", 100.0 },
                    { 75, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000075", "", "PURPEL CAKE", 0, 5.0, 10, "", 105.0 },
                    { 76, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000076", "", "RED VELVET CAKE", 0, 5.0, 10, "", 105.0 },
                    { 77, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000077", "", "STRAWBERRY DREAM CAKE", 0, 5.0, 10, "", 130.0 },
                    { 78, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000078", "", "STRAWBERRY GLAZE CAKE", 0, 5.0, 10, "", 100.0 },
                    { 79, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000079", "", "TIRAMISU CAKE", 0, 5.0, 10, "", 95.0 },
                    { 80, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000080", "", "VANILLA CREAM CAKE", 0, 5.0, 10, "", 75.0 },
                    { 81, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000081", "", "WHITE FOREST CAKE", 0, 5.0, 10, "", 75.0 },
                    { 82, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000082", "", "BOMBOLINO", 0, 5.0, 11, "", 50.0 },
                    { 83, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000083", "", "CHOCOLATE CROISSANT", 0, 5.0, 11, "", 80.0 },
                    { 84, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000084", "", "CHOCOLATE MUFFIN", 0, 5.0, 11, "", 55.0 },
                    { 85, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000085", "", "CROISSANT", 0, 5.0, 11, "", 70.0 },
                    { 86, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000086", "", "DOUGNUTS", 0, 5.0, 11, "", 55.0 },
                    { 87, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000087", "", "ENGLISH CAKE", 0, 5.0, 11, "", 55.0 },
                    { 88, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000088", "", "FASTING CROISSANT", 0, 5.0, 11, "", 60.0 },
                    { 89, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000089", "", "FASTING ENGLISH CAKE", 0, 5.0, 11, "", 50.0 },
                    { 90, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000090", "", "FASTING VENUS", 0, 5.0, 11, "", 40.0 },
                    { 91, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000091", "", "FRUIT TART", 0, 5.0, 11, "", 80.0 },
                    { 92, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000092", "", "FULL MULMUL", 0, 5.0, 11, "", 400.0 },
                    { 93, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000093", "", "HALF MULMUL", 0, 5.0, 11, "", 200.0 },
                    { 94, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000094", "", "VANILLA MUFFINE", 0, 5.0, 11, "", 90.0 },
                    { 95, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000095", "", "VENUS CAKE", 0, 5.0, 11, "", 40.0 },
                    { 96, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000096", "", "ZEBIB CAKE", 0, 5.0, 11, "", 55.0 },
                    { 97, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000097", "", "2KG BLACK FOREST TORTA", 0, 5.0, 12, "", 1700.0 },
                    { 98, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000098", "", "2KG CARAMEL TORTA", 0, 5.0, 12, "", 1900.0 },
                    { 99, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-000099", "", "2KG CHOCOLATE TORTA", 0, 5.0, 12, "", 2100.0 },
                    { 100, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000100", "", "2KG FASTING TORTA", 0, 5.0, 12, "", 1700.0 },
                    { 102, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000102", "", "2KG FONDANT TORTA", 0, 5.0, 12, "", 2900.0 },
                    { 103, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000103", "", "2KG OPERA TORTA", 0, 5.0, 12, "", 2400.0 },
                    { 104, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000104", "", "2KG RED VALET TORTA", 0, 5.0, 12, "", 2400.0 },
                    { 105, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000105", "", "2KG TIRAMISU TORTA", 0, 5.0, 12, "", 1900.0 },
                    { 106, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000106", "", "2KG WHITE FOREST TORTA", 0, 5.0, 12, "", 1700.0 },
                    { 107, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000107", "", "3KG BLACK FOREST TORTA", 0, 5.0, 12, "", 2500.0 },
                    { 108, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000108", "", "3KG CARAMEL TORTA", 0, 5.0, 12, "", 2700.0 },
                    { 109, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000109", "", "3KG CHOCOLATE TORTA", 0, 5.0, 12, "", 3200.0 },
                    { 110, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000110", "", "3KG FASTING WHITE FOREST TORTA", 0, 5.0, 12, "", 2500.0 },
                    { 111, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000111", "", "3KG FONDANT TORTA", 0, 5.0, 12, "", 4300.0 },
                    { 112, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000112", "", "3KG OPERA TORTA", 0, 5.0, 12, "", 3400.0 },
                    { 113, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000113", "", "BOMBOLINO", 0, 5.0, 12, "", 2500.0 },
                    { 114, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000114", "", "4KG BLACK FOREST TORTA", 0, 5.0, 12, "", 3400.0 },
                    { 115, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000115", "", "4KG CARAMEL TORTA", 0, 5.0, 12, "", 3600.0 },
                    { 116, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000116", "", "4KG FASTING WHITE FOREST TORTA", 0, 5.0, 12, "", 3400.0 },
                    { 117, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000117", "", "4KG FONDANT TORTA", 0, 5.0, 12, "", 5300.0 },
                    { 118, false, 0, new TimeOnly(0, 0, 0), 3, 0.0, "http://karavancoffee1-001-site1.atempurl.com/Images/Products/NoPicture.jpg", false, "PML-0000118", "", "4KG OPERA TORTA", 0, 5.0, 12, "", 4400.0 }
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

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_SubCategoryId",
                table: "Products",
                column: "SubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategories",
                column: "CategoryId");
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
                name: "Galleries");

            migrationBuilder.DropTable(
                name: "Ingredients");

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

            migrationBuilder.DropTable(
                name: "SubCategories");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}

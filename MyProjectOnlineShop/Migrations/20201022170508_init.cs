using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyProjectOnlineShop.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Sum = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    DescriptionFull = table.Column<string>(maxLength: 500, nullable: true),
                    ImgPath = table.Column<string>(nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
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
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Country = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Town = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    OrderComment = table.Column<string>(nullable: true),
                    OrderId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customer_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CustomerCart",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OrderId = table.Column<Guid>(nullable: false),
                    ProductBaseId = table.Column<Guid>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerCart_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AdditionalPicture",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductBaseId = table.Column<Guid>(nullable: false),
                    AdditionalImgPath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdditionalPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdditionalPicture_Products_ProductBaseId",
                        column: x => x.ProductBaseId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductRatings",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductBaseId = table.Column<Guid>(nullable: false),
                    RatingTotal = table.Column<int>(nullable: true),
                    VotesCount = table.Column<int>(nullable: true),
                    Rating = table.Column<double>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductRatings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductRatings_Products_ProductBaseId",
                        column: x => x.ProductBaseId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductReview",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductBaseId = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReview", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductReview_Products_ProductBaseId",
                        column: x => x.ProductBaseId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "014050AE-8FAA-4EA6-A0A4-DF7385C578E2", "860027ce-1113-4023-8430-29ec4b14c4b5", "admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0DEC5C45-E146-4562-883A-2499CB6A7F27", 0, "48bce2b3-0e79-4056-8268-cf1792171a5c", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEJFzJSnbwMqipQqdZAmbXin8c0AY2oCJHyoAs4KXhx16JLRIPmjxGccaaRyduOy5tw==", null, false, "", false, "admin" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "DescriptionFull", "ImgPath", "Name", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("7336cbb0-8170-48fb-bb6b-ea7ef1d1a87c"), "White modern chair", "1.jpg", "Modern chair", 200m, 10 },
                    { new Guid("20b98ce5-fc42-44ee-805f-26e35a51b056"), "Plant pot for your favorite plants", "5.jpg", "Plant pot", 25m, 18 },
                    { new Guid("2610d2d4-e4d7-417f-84df-ca3d4752f981"), "Chair for minimalists", "7.jpg", "Backless chair", 225m, 7 },
                    { new Guid("7be540cb-3e09-4ab2-b6e3-50217ff52cf1"), "White modern table", "product4.jpg", "Modern table", 330m, 11 },
                    { new Guid("f3a7412c-c5e5-4822-a60d-155e1dd060e0"), "Extra comfortable chair", "8.jpg", "Rocking chair", 290m, 6 },
                    { new Guid("e4266357-fd88-4f35-bfae-8ce79a3c7dfa"), "Let there be light", "product6.jpg", "Hanging lamp", 50m, 22 }
                });

            migrationBuilder.InsertData(
                table: "AdditionalPicture",
                columns: new[] { "Id", "AdditionalImgPath", "ProductBaseId" },
                values: new object[,]
                {
                    { new Guid("3639063a-f789-44dc-8bf4-2eb56d0d2add"), "pro-big-2.jpg", new Guid("7336cbb0-8170-48fb-bb6b-ea7ef1d1a87c") },
                    { new Guid("54358209-48b1-4fb7-b492-a8d748ce0c65"), "pro-big-3.jpg", new Guid("7336cbb0-8170-48fb-bb6b-ea7ef1d1a87c") },
                    { new Guid("55f4802f-b016-465a-a890-cdc37a7bf5d5"), "pro-big-1.jpg", new Guid("20b98ce5-fc42-44ee-805f-26e35a51b056") },
                    { new Guid("1b7f7d60-db80-49e6-8689-1686929c9671"), "pro-big-3.jpg", new Guid("20b98ce5-fc42-44ee-805f-26e35a51b056") },
                    { new Guid("428b6d63-4957-4acd-8d20-d8f5effebc82"), "pro-big-1.jpg", new Guid("2610d2d4-e4d7-417f-84df-ca3d4752f981") },
                    { new Guid("b931c7c4-d16f-4bd0-a727-24660b0a41a4"), "pro-big-2.jpg", new Guid("2610d2d4-e4d7-417f-84df-ca3d4752f981") },
                    { new Guid("84a9b1d0-8088-4f16-857a-fc132edeafd1"), "4.jpg", new Guid("7be540cb-3e09-4ab2-b6e3-50217ff52cf1") },
                    { new Guid("1230d89a-8452-4101-8167-c43f5471ed87"), "3.jpg", new Guid("7be540cb-3e09-4ab2-b6e3-50217ff52cf1") },
                    { new Guid("20664de3-ddc6-414d-b0a3-076d0724072a"), "pro-big-1.jpg", new Guid("f3a7412c-c5e5-4822-a60d-155e1dd060e0") },
                    { new Guid("dccfed5d-dfda-4fa3-a66c-d00f0d2f3f0c"), "pro-big-3.jpg", new Guid("f3a7412c-c5e5-4822-a60d-155e1dd060e0") },
                    { new Guid("efd2cc92-b8c5-4f54-b0db-696d7273c5ca"), "pro-big-4.jpg", new Guid("e4266357-fd88-4f35-bfae-8ce79a3c7dfa") },
                    { new Guid("f240f84c-9f87-466e-a733-af6e0a4b42b7"), "pro-big-2.jpg", new Guid("e4266357-fd88-4f35-bfae-8ce79a3c7dfa") }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "0DEC5C45-E146-4562-883A-2499CB6A7F27", "014050AE-8FAA-4EA6-A0A4-DF7385C578E2" });

            migrationBuilder.CreateIndex(
                name: "IX_AdditionalPicture_ProductBaseId",
                table: "AdditionalPicture",
                column: "ProductBaseId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

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
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customer_OrderId",
                table: "Customer",
                column: "OrderId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CustomerCart_OrderId",
                table: "CustomerCart",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductRatings_ProductBaseId",
                table: "ProductRatings",
                column: "ProductBaseId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductReview_ProductBaseId",
                table: "ProductReview",
                column: "ProductBaseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdditionalPicture");

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
                name: "Customer");

            migrationBuilder.DropTable(
                name: "CustomerCart");

            migrationBuilder.DropTable(
                name: "ProductRatings");

            migrationBuilder.DropTable(
                name: "ProductReview");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}

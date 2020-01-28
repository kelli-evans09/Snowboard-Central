using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SnowboardCentral.Migrations
{
    public partial class SeedData1 : Migration
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
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    NewUserName = table.Column<string>(nullable: true),
                    Height = table.Column<int>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    ExperienceLevelId = table.Column<int>(nullable: false),
                    Age = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExperienceLevels",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Level = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExperienceLevels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Resorts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    WeekdayHours = table.Column<string>(nullable: true),
                    WeekendHours = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Lodging = table.Column<bool>(nullable: false),
                    RentEquipment = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    UrlImage = table.Column<string>(nullable: true),
                    DailyCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resorts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Shops",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    WeekdayHours = table.Column<string>(nullable: true),
                    WeekendHours = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    RentEquipment = table.Column<bool>(nullable: false),
                    Url = table.Column<string>(nullable: true),
                    UrlImage = table.Column<string>(nullable: true),
                    DailyRentalCost = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shops", x => x.Id);
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
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
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
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
                name: "ResortReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ResortId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    DetailReview = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResortReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResortReviews_Resorts_ResortId",
                        column: x => x.ResortId,
                        principalTable: "Resorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResortReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShopReviews",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShopId = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    DetailReview = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShopReviews_Shops_ShopId",
                        column: x => x.ShopId,
                        principalTable: "Shops",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShopReviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Age", "ConcurrencyStamp", "Email", "EmailConfirmed", "ExperienceLevelId", "FirstName", "Height", "LastName", "LockoutEnabled", "LockoutEnd", "NewUserName", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Weight" },
                values: new object[] { "00000000-ffff-ffff-ffff-ffffffffffff", 0, 29, "63e76c8f-2c95-4b9f-8975-c6aff927e05c", "admin@admin.com", true, 1, "Kelli", 69, "Evans", false, null, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAELidVKcDGcEI6TkZm3Su5aVGEhchgy+I2Epu6I5DBRLGX1wwkMQSGzXfT/bMifi0XQ==", null, false, "7f434309-a4d9-48e9-9ebb-8803db794577", false, "admin@admin.com", 130 });

            migrationBuilder.InsertData(
                table: "ExperienceLevels",
                columns: new[] { "Id", "Level" },
                values: new object[,]
                {
                    { 1, "Beginner" },
                    { 2, "Intermediate" },
                    { 3, "Advanced" },
                    { 4, "Expert" }
                });

            migrationBuilder.InsertData(
                table: "Resorts",
                columns: new[] { "Id", "Address", "DailyCost", "Description", "Lodging", "Name", "PhoneNumber", "RentEquipment", "Url", "UrlImage", "WeekdayHours", "WeekendHours" },
                values: new object[,]
                {
                    { 1, "1000 Snow Valley Rd Zanesville, OH 43360", 40.0, "Amenities: Lodging, restaurants, shuttle services, vehicle charging stations, chapel, and much more!", true, "Mad River Mountain", "800-231-7669", true, "https://www.skimadriver.com/", null, "10am - 9:30pm", "9am - 9:30pm" },
                    { 2, "3100 Possum Run Rd, Mansfield, OH 44903", 50.0, "Opened in 1961, this family-owned resort with a lodge features winter skiing, snowboarding & tubing.", true, "Snow Trails", "419-774-9818", true, "https://www.snowtrails.com/", null, "10am - 9pm", "9am - 9pm" },
                    { 3, "10620 Mayfield Rd, Chesterland, OH 44026", 45.0, "Alpine Valley Ski Area is a ski resort located in Munson Township, Geauga County, in the U.S. state of Ohio, east of Chesterland. It was built in 1965 under the direction of Thomas D. Apthorp, who then continued to operate and manage the resort until 2007.", true, "Alpine Valley", "440-285-2211", true, "http://www.alpinevalleyohio.com/", null, "3:30pm - 9pm", "9am - 9pm" }
                });

            migrationBuilder.InsertData(
                table: "Shops",
                columns: new[] { "Id", "Address", "DailyRentalCost", "Description", "Name", "PhoneNumber", "RentEquipment", "Url", "UrlImage", "WeekdayHours", "WeekendHours" },
                values: new object[,]
                {
                    { 1, "1170 E Powell Rd Lewis Center, OH 43035", 50.0, "We offer over 65 of the top brands of jackets, pants, base layers, skis, snowboards, boots, bindings, tuning equipment, helmets, goggles and more!", "Aspen Ski and Board", "614-848-6600", true, "https://www.aspenskiandboard.com/", null, "11am - 8:30pm", "10am - 6pm" },
                    { 2, "4445 Cemetery Rd, Hilliard, OH 43026", 75.0, "This is a description", "Colorado Mountain Sports", "614-459-6666", true, "https://coloradomtnsports.com/", null, "11am - 8pm", "10am - 6pm" },
                    { 3, "5043 Tuttle Crossing Blvd #162, Dublin, OH 43016", 60.0, "This is a description", "Zumiez", "614-798-2018", true, "https://www.zumiez.com/", null, "10am - 9pm", "11am - 6pm" }
                });

            migrationBuilder.InsertData(
                table: "ResortReviews",
                columns: new[] { "Id", "DetailReview", "Rating", "ResortId", "UserId" },
                values: new object[,]
                {
                    { 1, "Love the selection of slopes here!", 5, 1, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, "Pretty sweet place to board", 5, 2, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 3, "Not as many slopes to choose from but it was fun", 3, 3, "00000000-ffff-ffff-ffff-ffffffffffff" }
                });

            migrationBuilder.InsertData(
                table: "ShopReviews",
                columns: new[] { "Id", "DetailReview", "Rating", "ShopId", "UserId" },
                values: new object[,]
                {
                    { 1, "This place is fucking awesome", 5, 1, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 2, "This place is alright", 3, 2, "00000000-ffff-ffff-ffff-ffffffffffff" },
                    { 3, "The name of this place is kinda entertaining", 4, 3, "00000000-ffff-ffff-ffff-ffffffffffff" }
                });

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
                name: "IX_ResortReviews_ResortId",
                table: "ResortReviews",
                column: "ResortId");

            migrationBuilder.CreateIndex(
                name: "IX_ResortReviews_UserId",
                table: "ResortReviews",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopReviews_ShopId",
                table: "ShopReviews",
                column: "ShopId");

            migrationBuilder.CreateIndex(
                name: "IX_ShopReviews_UserId",
                table: "ShopReviews",
                column: "UserId");
        }

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
                name: "ExperienceLevels");

            migrationBuilder.DropTable(
                name: "ResortReviews");

            migrationBuilder.DropTable(
                name: "ShopReviews");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Resorts");

            migrationBuilder.DropTable(
                name: "Shops");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}

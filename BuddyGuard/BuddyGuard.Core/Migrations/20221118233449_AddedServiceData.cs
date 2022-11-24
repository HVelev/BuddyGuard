using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGuard.Core.Migrations
{
    public partial class AddedServiceData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimalTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Address = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Prices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prices", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
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
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stars = table.Column<int>(type: "int", nullable: false),
                    PublishedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PriceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locations_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WalkLength = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsForCustomer = table.Column<bool>(type: "bit", nullable: false),
                    AnimalTypeId = table.Column<int>(type: "int", nullable: true),
                    PriceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Prices_PriceId",
                        column: x => x.PriceId,
                        principalTable: "Prices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Requests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    IsAccepted = table.Column<bool>(type: "bit", nullable: false),
                    RequestSentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Requests_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Requests_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnimalRequests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalSpecies = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    AnimalTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalRequests_AnimalTypes_AnimalTypeId",
                        column: x => x.AnimalTypeId,
                        principalTable: "AnimalTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalRequests_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequestServices",
                columns: table => new
                {
                    RequestId = table.Column<int>(type: "int", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false),
                    AnimalRequestId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequestServices", x => new { x.ServiceId, x.RequestId });
                    table.ForeignKey(
                        name: "FK_RequestServices_AnimalRequests_AnimalRequestId",
                        column: x => x.AnimalRequestId,
                        principalTable: "AnimalRequests",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequestServices_Requests_RequestId",
                        column: x => x.RequestId,
                        principalTable: "Requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RequestServices_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AnimalTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Малко куче" },
                    { 2, "Голямо куче" },
                    { 3, "Котка" },
                    { 4, "Друго" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "3842e409-193c-4372-9d01-dbd1353d8158", "9aa905fd-5e5b-40e0-8869-80d6fe97f385", "Admin", null },
                    { "d72e38d2-1eba-44f4-9a50-0b10dbad12bb", "206d98fd-d512-4868-9d37-74ed7953fcb2", "User", null }
                });

            migrationBuilder.InsertData(
                table: "Prices",
                columns: new[] { "Id", "Amount" },
                values: new object[,]
                {
                    { 1, 5m },
                    { 2, 8m },
                    { 3, 14m },
                    { 4, 16m },
                    { 5, 21m },
                    { 6, 12m },
                    { 7, 17m },
                    { 8, 19m },
                    { 9, 24m },
                    { 10, 29m },
                    { 11, 10m },
                    { 12, 0m },
                    { 13, 3.50m },
                    { 14, 2.99m },
                    { 15, 19.99m },
                    { 16, 6m },
                    { 17, 4.99m },
                    { 18, 14.99m },
                    { 19, 5.99m }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name", "PriceId" },
                values: new object[,]
                {
                    { 1, "Абдовица", 1 },
                    { 2, "Банишора", 1 },
                    { 3, "Барите", 1 },
                    { 4, "Белите брези", 1 },
                    { 5, "Бенковски", 1 },
                    { 6, "Бизнес парк София", 1 },
                    { 7, "Бокар", 1 },
                    { 8, "Борово", 1 },
                    { 9, "Ботунец", 1 },
                    { 10, "Бояна", 1 },
                    { 11, "Бункера", 1 },
                    { 12, "Бъкстон", 1 },
                    { 13, "Витоша", 1 },
                    { 14, "Владимир Заимов", 1 },
                    { 15, "Враждебна", 1 },
                    { 16, "Връбница", 1 },
                    { 17, "Връбница-1", 1 },
                    { 18, "Връбница-2", 1 },
                    { 19, "Гевгелийски квартал", 1 },
                    { 20, "Гео Милев", 1 },
                    { 21, "Горна баня", 1 },
                    { 22, "Горубляне", 1 },
                    { 23, "Гоце Делчев", 1 },
                    { 24, "Дианабад", 1 },
                    { 25, "Димитър Миленков", 1 },
                    { 26, "Драгалевци", 1 },
                    { 27, "Драз махала", 1 },
                    { 28, "Дружба", 1 },
                    { 29, "Дървеница", 1 },
                    { 30, "Западен парк", 1 },
                    { 31, "Захарна фабрика", 1 },
                    { 32, "Зона Б-18", 1 },
                    { 33, "Зона Б-19", 1 },
                    { 34, "Зона Б-5-3", 1 },
                    { 35, "Иван Вазов", 1 },
                    { 36, "Изгрев", 1 },
                    { 37, "Изток", 1 },
                    { 38, "Илинден", 1 },
                    { 39, "Илиянци", 1 },
                    { 40, "Киноцентър", 1 },
                    { 41, "Княжево", 1 },
                    { 42, "Красна поляна", 1 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name", "PriceId" },
                values: new object[,]
                {
                    { 43, "Красно село", 1 },
                    { 44, "Кремиковци", 1 },
                    { 45, "Крива река", 1 },
                    { 46, "Кръстова вада", 1 },
                    { 47, "Кюлуците", 1 },
                    { 48, "Лагера", 1 },
                    { 49, "Лев Толстой", 1 },
                    { 50, "Левски", 1 },
                    { 51, "Лозенец", 1 },
                    { 52, "Люлин", 1 },
                    { 53, "Малашевци", 1 },
                    { 54, "Малинова долина", 1 },
                    { 55, "Манастирски ливади", 1 },
                    { 56, "Младост", 1 },
                    { 57, "Младост 1А", 1 },
                    { 58, "Младост 2", 1 },
                    { 59, "Младост 3", 1 },
                    { 60, "Младост 4", 1 },
                    { 61, "Модерно преградие", 1 },
                    { 62, "Момкова махала", 1 },
                    { 63, "Мотописта", 1 },
                    { 64, "Мусагеница", 1 },
                    { 65, "Надежда", 1 },
                    { 66, "Обеля", 1 },
                    { 67, "Оборище", 1 },
                    { 68, "Овча Купел", 1 },
                    { 69, "Овча Купел 1", 1 },
                    { 70, "Овча Купел 2", 1 },
                    { 71, "Орландовци", 1 },
                    { 72, "Павлово", 1 },
                    { 73, "Подуяне", 1 },
                    { 74, "Полигона", 1 },
                    { 75, "Разсадника-Коньовица", 1 },
                    { 76, "Редута", 1 },
                    { 77, "Република", 1 },
                    { 78, "Света Троица", 1 },
                    { 79, "Свобода", 1 },
                    { 80, "Сердика", 1 },
                    { 81, "Сеславци", 1 },
                    { 82, "Симеоново", 1 },
                    { 83, "Славия", 1 },
                    { 84, "Слатина", 1 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name", "PriceId" },
                values: new object[,]
                {
                    { 85, "Стефан Караджа", 1 },
                    { 86, "Стрелбище", 1 },
                    { 87, "Студентски град", 1 },
                    { 88, "Сухата река", 1 },
                    { 89, "Суходол", 1 },
                    { 90, "Требич", 1 },
                    { 91, "Триъгълника", 1 },
                    { 92, "Факултета", 1 },
                    { 93, "Филиповци", 1 },
                    { 94, "Фондови жилища", 1 },
                    { 95, "Хаджи Димитър", 1 },
                    { 96, "Хиподрума", 1 },
                    { 97, "Хладилника", 1 },
                    { 98, "Христо Ботев", 1 },
                    { 99, "Цариградски комплекс", 1 },
                    { 100, "Център", 1 },
                    { 101, "Челопечене", 1 },
                    { 102, "Чепинско шосе", 1 },
                    { 103, "Южен парк", 1 },
                    { 104, "Ючбунар", 1 },
                    { 105, "Яворов", 1 }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "AnimalTypeId", "IsForCustomer", "Name", "PriceId", "WalkLength" },
                values: new object[,]
                {
                    { 1, 1, false, "Две разходки без камера", 2, "30 минути" },
                    { 2, 1, false, "Две разходки с камера", 3, "30 минути" },
                    { 3, 1, false, "Разходка без камера", 1, "30 минути" },
                    { 4, 1, false, "Разходка с камера", 2, "30 минути" },
                    { 5, 1, false, "Две разходки без камера", 4, "60 минути" },
                    { 6, 1, false, "Две разходки с камера", 9, "60 минути" },
                    { 7, 1, false, "Разходка без камера", 11, "60 минути" },
                    { 8, 1, false, "Разходка с камера", 3, "60 минути" },
                    { 9, 1, false, "Две разходки без камера", 6, "Комбинирана (30мин + 60мин)" },
                    { 10, 1, false, "Две разходки с камера", 8, "Комбинирани (30мин + 60мин)" },
                    { 11, 2, false, "Две разходки без камера", 6, "30 минути" },
                    { 12, 2, false, "Две разходки с камера", 8, "30 минути" },
                    { 13, 2, false, "Разходка без камера", 2, "30 минути" },
                    { 14, 2, false, "Разходка с камера", 6, "30 минути" },
                    { 15, 2, false, "Две разходки без камера", 5, "60 минути" },
                    { 16, 2, false, "Две разходки с камера", 10, "60 минути" },
                    { 17, 2, false, "Разходка без камера", 3, "60 минути" },
                    { 18, 2, false, "Разходка с камера", 8, "60 минути" },
                    { 19, 2, false, "Две разходки без камера", 7, "Комбинирани (30мин + 60мин)" },
                    { 20, 2, false, "Две разходки с камера", 9, "Комбинирани (30мин + 60мин)" },
                    { 21, null, false, "Еднократно ресане", 17, null }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "AnimalTypeId", "IsForCustomer", "Name", "PriceId", "WalkLength" },
                values: new object[,]
                {
                    { 22, null, false, "Цялостно къпане", 18, null },
                    { 23, 3, false, "Разходка навън", 19, null },
                    { 24, null, true, "Ветеринарен преглед", 15, null },
                    { 25, null, true, "Събиране на поща", 13, null },
                    { 26, null, true, "Посрещане/Изпращане на пратка", 13, null },
                    { 27, null, true, "Еднократно поливане на цветя", 14, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalRequests_AnimalTypeId",
                table: "AnimalRequests",
                column: "AnimalTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalRequests_RequestId",
                table: "AnimalRequests",
                column: "RequestId");

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
                name: "IX_Locations_PriceId",
                table: "Locations",
                column: "PriceId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_LocationId",
                table: "Requests",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Requests_UserId",
                table: "Requests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestServices_AnimalRequestId",
                table: "RequestServices",
                column: "AnimalRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_RequestServices_RequestId",
                table: "RequestServices",
                column: "RequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_PriceId",
                table: "Services",
                column: "PriceId");
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
                name: "Posts");

            migrationBuilder.DropTable(
                name: "RequestServices");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AnimalRequests");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "AnimalTypes");

            migrationBuilder.DropTable(
                name: "Requests");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Prices");
        }
    }
}

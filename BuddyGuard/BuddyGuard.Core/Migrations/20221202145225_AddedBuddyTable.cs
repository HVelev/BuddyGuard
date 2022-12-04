using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGuard.Core.Migrations
{
    public partial class AddedBuddyTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buddies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Image = table.Column<byte[]>(type: "image", nullable: false),
                    PublishedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buddies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Buddies_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 73,
                column: "Name",
                value: "Павлово");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 74,
                column: "Name",
                value: "Подуяне");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 75,
                column: "Name",
                value: "Полигона");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 76,
                column: "Name",
                value: "Разсадника-Коньовица");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 77,
                column: "Name",
                value: "Редута");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 78,
                column: "Name",
                value: "Република");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 79,
                column: "Name",
                value: "Света Троица");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 80,
                column: "Name",
                value: "Свобода");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 81,
                column: "Name",
                value: "Сердика");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 82,
                column: "Name",
                value: "Сеславци");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 83,
                column: "Name",
                value: "Симеоново");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 84,
                column: "Name",
                value: "Славия");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 85,
                column: "Name",
                value: "Слатина");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 86,
                column: "Name",
                value: "Стефан Караджа");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 87,
                column: "Name",
                value: "Стрелбище");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 88,
                column: "Name",
                value: "Студентски град");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 89,
                column: "Name",
                value: "Сухата река");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 90,
                column: "Name",
                value: "Суходол");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 91,
                column: "Name",
                value: "Требич");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 92,
                column: "Name",
                value: "Триъгълника");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 93,
                column: "Name",
                value: "Факултета");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 94,
                column: "Name",
                value: "Филиповци");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 95,
                column: "Name",
                value: "Фондови жилища");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 96,
                column: "Name",
                value: "Хаджи Димитър");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 97,
                column: "Name",
                value: "Хиподрума");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 98,
                column: "Name",
                value: "Хладилника");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 99,
                column: "Name",
                value: "Христо Ботев");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 100,
                column: "Name",
                value: "Цариградски комплекс");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 101,
                column: "Name",
                value: "Център");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 102,
                column: "Name",
                value: "Челопечене");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 103,
                column: "Name",
                value: "Чепинско шосе");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 104,
                column: "Name",
                value: "Южен парк");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 105,
                column: "Name",
                value: "Ючбунар");

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Name", "PriceId" },
                values: new object[] { 106, "Яворов", 1 });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "WalkLength",
                value: "Комбинирани (30мин + 60мин)");

            migrationBuilder.CreateIndex(
                name: "IX_Buddies_UserId",
                table: "Buddies",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Buddies");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 73,
                column: "Name",
                value: "Подуяне");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 74,
                column: "Name",
                value: "Полигона");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 75,
                column: "Name",
                value: "Разсадника-Коньовица");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 76,
                column: "Name",
                value: "Редута");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 77,
                column: "Name",
                value: "Република");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 78,
                column: "Name",
                value: "Света Троица");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 79,
                column: "Name",
                value: "Свобода");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 80,
                column: "Name",
                value: "Сердика");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 81,
                column: "Name",
                value: "Сеславци");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 82,
                column: "Name",
                value: "Симеоново");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 83,
                column: "Name",
                value: "Славия");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 84,
                column: "Name",
                value: "Слатина");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 85,
                column: "Name",
                value: "Стефан Караджа");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 86,
                column: "Name",
                value: "Стрелбище");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 87,
                column: "Name",
                value: "Студентски град");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 88,
                column: "Name",
                value: "Сухата река");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 89,
                column: "Name",
                value: "Суходол");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 90,
                column: "Name",
                value: "Требич");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 91,
                column: "Name",
                value: "Триъгълника");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 92,
                column: "Name",
                value: "Факултета");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 93,
                column: "Name",
                value: "Филиповци");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 94,
                column: "Name",
                value: "Фондови жилища");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 95,
                column: "Name",
                value: "Хаджи Димитър");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 96,
                column: "Name",
                value: "Хиподрума");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 97,
                column: "Name",
                value: "Хладилника");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 98,
                column: "Name",
                value: "Христо Ботев");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 99,
                column: "Name",
                value: "Цариградски комплекс");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 100,
                column: "Name",
                value: "Център");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 101,
                column: "Name",
                value: "Челопечене");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 102,
                column: "Name",
                value: "Чепинско шосе");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 103,
                column: "Name",
                value: "Южен парк");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 104,
                column: "Name",
                value: "Ючбунар");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 105,
                column: "Name",
                value: "Яворов");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 9,
                column: "WalkLength",
                value: "Комбинирана (30мин + 60мин)");
        }
    }
}

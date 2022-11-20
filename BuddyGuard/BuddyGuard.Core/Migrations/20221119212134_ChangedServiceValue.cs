using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGuard.Core.Migrations
{
    public partial class ChangedServiceValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3842e409-193c-4372-9d01-dbd1353d8158");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d72e38d2-1eba-44f4-9a50-0b10dbad12bb");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "72941a72-f1cd-4441-bec0-5a3b3d699010", "4a71412e-425c-4d48-bc12-a55e2e0226d7", "User", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fc206617-15a3-45d7-88dd-b17f1c977a07", "91242cee-ea5e-4934-a786-1ae62d539853", "Admin", null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 24,
                column: "IsForCustomer",
                value: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "72941a72-f1cd-4441-bec0-5a3b3d699010");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fc206617-15a3-45d7-88dd-b17f1c977a07");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3842e409-193c-4372-9d01-dbd1353d8158", "9aa905fd-5e5b-40e0-8869-80d6fe97f385", "Admin", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d72e38d2-1eba-44f4-9a50-0b10dbad12bb", "206d98fd-d512-4868-9d37-74ed7953fcb2", "User", null });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "Id",
                keyValue: 24,
                column: "IsForCustomer",
                value: true);
        }
    }
}

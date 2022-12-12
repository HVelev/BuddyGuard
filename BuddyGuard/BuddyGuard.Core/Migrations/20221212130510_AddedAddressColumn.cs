using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGuard.Core.Migrations
{
    public partial class AddedAddressColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Requests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f107bb9-9810-4024-b4e3-182d696421ab",
                column: "ConcurrencyStamp",
                value: "ab9b335e-c586-4610-ac5c-cbedee762549");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0143a5-0c68-4c92-92d5-34965e2ca95d",
                column: "ConcurrencyStamp",
                value: "6fb605ad-4285-42a4-a6d7-8d6c02f7d4c3");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "307894cc-5f1e-4792-ae6b-40293f3dedb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "78c9f483-3053-4cc7-bb50-c3406cb57400", "AQAAAAEAACcQAAAAEOJELLrywhtDFmoI55LNIDN08mBG2G/Y3GiZ0kcpuKAOFl8z1N5et5mc3zHI/TvPjg==", "417d637b-03f8-4ed7-96ab-88daac747fff" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fe60605-1716-4010-abc6-ddacfd3ecf9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10df7d25-3ac5-49bc-890a-9ab86bf703ed", "AQAAAAEAACcQAAAAECVX4VNivkyWKhib5bXs0YH7Q7xMw4bKcBSUxSb5d84CCQZbZ5zZMfyqrMyLWpaLpw==", "9b4e9c87-ecfd-4b6e-8a8c-126b42eddc7a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Requests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f107bb9-9810-4024-b4e3-182d696421ab",
                column: "ConcurrencyStamp",
                value: "6dea156c-6efa-45ac-ad2f-7ffa547e3116");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0143a5-0c68-4c92-92d5-34965e2ca95d",
                column: "ConcurrencyStamp",
                value: "6ed0fd35-9098-40bd-a6aa-bdb0cf314d25");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "307894cc-5f1e-4792-ae6b-40293f3dedb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3d4c8fb1-574d-4f8b-9ace-0a6093db8792", "AQAAAAEAACcQAAAAEOred8Fe7rz4Uvn9dK+Epx7ecqHXeSh9dLTTJmXRt09tMzg4fyY5oLOxRiMvzlc/Mw==", "717011db-26c8-494a-b7fb-0ea961a8f17b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fe60605-1716-4010-abc6-ddacfd3ecf9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6738ceb4-c5f7-4671-8c1e-6f8c9ef48188", "AQAAAAEAACcQAAAAEHZgNo9gtVaN1TVnnbPME5R+B05K9ofwgx9hPXbaOj8/O+1yn7RISiVC4I0F4+zsxA==", "0bea2d57-f876-4898-ac6e-aaeea19569f0" });
        }
    }
}

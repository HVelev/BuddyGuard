using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGuard.Core.Migrations
{
    public partial class Update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f107bb9-9810-4024-b4e3-182d696421ab",
                column: "ConcurrencyStamp",
                value: "3ca1e237-a8d1-4deb-ba1f-0f15916f21ca");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0143a5-0c68-4c92-92d5-34965e2ca95d",
                column: "ConcurrencyStamp",
                value: "81cdd548-4157-4e17-8b2d-1b35066b2e21");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "307894cc-5f1e-4792-ae6b-40293f3dedb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0d2a34b1-e6c3-4df8-a696-b2c19f74c57f", "AQAAAAEAACcQAAAAEPmiKO075slsjI8AoMWA0tSkat6vWA1E6fBWh4+tsHtq0UAsXRSpDe2elv3GG4Hn1Q==", "2ccfaf1a-78aa-4e94-97d3-0a3ac7e540de" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fe60605-1716-4010-abc6-ddacfd3ecf9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d1c1ddf1-0819-44e6-865c-b420cda58031", "AQAAAAEAACcQAAAAEAapeHyYyLLSK46U1dHTlbxXS/jOByUgYV1CIpym/GJd2AySsibOkFaMXF9bUwOJEg==", "e40842b9-385e-4ce3-9354-34f46f59bc43" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "Младост 1");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 73,
                column: "Name",
                value: "Панчарево");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "Младост");

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 73,
                column: "Name",
                value: "Павлово");
        }
    }
}

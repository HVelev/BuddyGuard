using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGuard.Core.Migrations
{
    public partial class AddedLocationIdCK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f107bb9-9810-4024-b4e3-182d696421ab",
                column: "ConcurrencyStamp",
                value: "13889fa4-621d-4aa3-b527-c47a68ac5907");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0143a5-0c68-4c92-92d5-34965e2ca95d",
                column: "ConcurrencyStamp",
                value: "72de5d6b-1b48-4dc6-99bb-f655c4dfe76b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "307894cc-5f1e-4792-ae6b-40293f3dedb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5258d86a-324b-446e-ad7f-3e82cef8cbd7", "AQAAAAEAACcQAAAAEJweY2E9hwAd81NKCtN+pRKgPrTPcw1UlEGLRpadpPZ4lfkxf8rEISTMDL/HGA3HJQ==", "92c28792-8db4-4389-aa11-5af26583abf7" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fe60605-1716-4010-abc6-ddacfd3ecf9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e246d98e-095c-42bb-970e-70c1d93b268c", "AQAAAAEAACcQAAAAEHzDMzXaRm3JarM0EwVTfjvy4T+h30nNayAdv6wweqj+V3qvIII6a0X9TSVvZz9MZA==", "c6a3c92f-9000-457c-9766-8d7c73cae7d9" });

            migrationBuilder.AddCheckConstraint(
                name: "CK_Request_LocationId",
                table: "Requests",
                sql: "LocationId > 0");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Request_LocationId",
                table: "Requests");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f107bb9-9810-4024-b4e3-182d696421ab",
                column: "ConcurrencyStamp",
                value: "d1577a0d-099c-4715-ab03-db2283b4622a");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0143a5-0c68-4c92-92d5-34965e2ca95d",
                column: "ConcurrencyStamp",
                value: "cd2dc108-955b-4b3d-8842-df73cdefc76a");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "307894cc-5f1e-4792-ae6b-40293f3dedb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ee1248a9-8001-4b24-8ebf-cfb4734e7975", "AQAAAAEAACcQAAAAEH34vJeiIIHh2XkkDSKwXs9htzi09RUfs/ceJxt12Xr71W6LQMHZru9QnPCIM+4qeg==", "93784b9f-37c4-4f12-bf06-e4b1eed94ede" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fe60605-1716-4010-abc6-ddacfd3ecf9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d0b121c8-6194-439f-b44b-426218e6c3ec", "AQAAAAEAACcQAAAAEEz9cU6QiWkfFvL9RMAHSS7HhSdbVLdZNv1jzQkEKYXcnMsiyFc3zA+HVYyim84bUA==", "52c6b7fd-6a68-4531-a4a2-d3aa4aa30420" });
        }
    }
}

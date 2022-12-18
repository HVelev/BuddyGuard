using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGuard.Core.Migrations
{
    public partial class Updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f107bb9-9810-4024-b4e3-182d696421ab",
                column: "ConcurrencyStamp",
                value: "1416def0-cdae-4723-a969-1f2dca077c43");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0143a5-0c68-4c92-92d5-34965e2ca95d",
                column: "ConcurrencyStamp",
                value: "d053823c-0554-47d3-86a3-7f4bb97ae421");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "307894cc-5f1e-4792-ae6b-40293f3dedb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6d33791-964b-4df7-b6dd-2ae0738b289d", "AQAAAAEAACcQAAAAEMuK0PXTZ1PH2ba6RpOHllu8qJa2RHeqbcHfFyVVjr/sKyrUUybtAdwZB4O6CZBe7Q==", "fcf93cab-b75d-4898-b410-e65a6fe27ed8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fe60605-1716-4010-abc6-ddacfd3ecf9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "709b77f6-47a2-445b-9d1f-b17a9c2e352e", "AQAAAAEAACcQAAAAEPig7XwuGXh87Gx9yy3PiQsS9vvSA91wvOZf3f9JIkVfdMwms10jpgmVbPjhYvPR+A==", "eacd3bb2-907b-4c66-ac57-c6a843473fee" });
        }
    }
}

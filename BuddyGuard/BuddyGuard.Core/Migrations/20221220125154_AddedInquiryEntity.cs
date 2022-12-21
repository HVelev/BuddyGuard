using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGuard.Core.Migrations
{
    public partial class AddedInquiryEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inquiries",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inquiries", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f107bb9-9810-4024-b4e3-182d696421ab",
                column: "ConcurrencyStamp",
                value: "28eb1b50-bf74-4253-aef7-30e3a9dbe5f3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0143a5-0c68-4c92-92d5-34965e2ca95d",
                column: "ConcurrencyStamp",
                value: "6560aa72-f494-4da6-8fe1-4d8f06b31a62");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "307894cc-5f1e-4792-ae6b-40293f3dedb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9858bd89-7f9c-4552-8611-ca1f7e3bf77e", "AQAAAAEAACcQAAAAEKGocHoDUMysq743lm6m6LBZcyrNJBzAPqBEllNGLTozZCRganLIHKXANs4ln5AbrQ==", "1e74b481-e2ce-4312-97f3-d566fcba0fa9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fe60605-1716-4010-abc6-ddacfd3ecf9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0257120e-fc87-4a90-9245-91695d47c334", "AQAAAAEAACcQAAAAEFDvpKTrAE69zoANSopHMOjyEFa2teYJ0WakgPR5ZIqYqFndOAaAnn2uo6ROP5UTyg==", "145a13a6-09b9-432f-a31e-bc83989469a1" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inquiries");

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
        }
    }
}

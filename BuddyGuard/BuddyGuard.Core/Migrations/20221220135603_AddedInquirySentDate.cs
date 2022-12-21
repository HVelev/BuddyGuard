using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGuard.Core.Migrations
{
    public partial class AddedInquirySentDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SentDate",
                table: "Inquiries",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f107bb9-9810-4024-b4e3-182d696421ab",
                column: "ConcurrencyStamp",
                value: "6597cb67-eb00-41db-81ab-36f8bb0b54c8");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0143a5-0c68-4c92-92d5-34965e2ca95d",
                column: "ConcurrencyStamp",
                value: "9f3f265b-12fc-4cb3-839f-296d2e8b7562");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "307894cc-5f1e-4792-ae6b-40293f3dedb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d3cff759-5c13-4ecb-a760-749fad28cbf3", "AQAAAAEAACcQAAAAEPVdrtR8njd8J/6uvIQZtHEewOKkXaoY0k9enIlNaeHLSpHFsbhfrLTyKezafs2P8w==", "06852420-64c5-4f7c-94dc-0a6c72d91111" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fe60605-1716-4010-abc6-ddacfd3ecf9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "67e707bb-7747-44b8-809e-4ad02aa82571", "AQAAAAEAACcQAAAAEMWFZjgfTa9DKS3Q6IDSfqPE+Zu7ga7kNTCALujc/zAm5OFoDm3A5o8ekax2gYB0MQ==", "b95097c6-c589-4df3-9d67-99d2f7a3bd48" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SentDate",
                table: "Inquiries");

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
    }
}

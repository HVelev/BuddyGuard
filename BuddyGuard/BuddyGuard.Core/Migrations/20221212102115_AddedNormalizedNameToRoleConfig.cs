using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGuard.Core.Migrations
{
    public partial class AddedNormalizedNameToRoleConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f107bb9-9810-4024-b4e3-182d696421ab",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "6dea156c-6efa-45ac-ad2f-7ffa547e3116", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0143a5-0c68-4c92-92d5-34965e2ca95d",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "6ed0fd35-9098-40bd-a6aa-bdb0cf314d25", "USER" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f107bb9-9810-4024-b4e3-182d696421ab",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "2c203cd1-070f-445c-a3f4-ca707d9adefb", null });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0143a5-0c68-4c92-92d5-34965e2ca95d",
                columns: new[] { "ConcurrencyStamp", "NormalizedName" },
                values: new object[] { "e3f21efd-d63c-4c67-a908-ed98bec360df", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "307894cc-5f1e-4792-ae6b-40293f3dedb5",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7814d5b-9cb2-4352-a275-cfa45e4896ae", "AQAAAAEAACcQAAAAEPZzS/VXZhCOXDdkHMYHHhyFflt8VwFKcsSGyjGhKTja5Zpe9JzNQDnpE8rtRFAR7A==", "1d961dd3-6022-4d97-93c7-e0083adafdf8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fe60605-1716-4010-abc6-ddacfd3ecf9b",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4eec162-905c-43b3-b318-65f34b7bbe64", "AQAAAAEAACcQAAAAEKa8FIX8RMn7HeCAp9C21gY90GEvCoz/ivZtjFFQV+ZcPzrusI+xfy99H4IfuzST6w==", "38428f1a-bc61-454d-9835-adc72726a8da" });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGuard.Core.Migrations
{
    public partial class UserConfigurationChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f107bb9-9810-4024-b4e3-182d696421ab",
                column: "ConcurrencyStamp",
                value: "2c203cd1-070f-445c-a3f4-ca707d9adefb");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0143a5-0c68-4c92-92d5-34965e2ca95d",
                column: "ConcurrencyStamp",
                value: "e3f21efd-d63c-4c67-a908-ed98bec360df");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "307894cc-5f1e-4792-ae6b-40293f3dedb5",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7814d5b-9cb2-4352-a275-cfa45e4896ae", "buddyguardapp@outlook.com", "BUDDYGUARDAPP@OUTLOOK.COM", "USER", "AQAAAAEAACcQAAAAEPZzS/VXZhCOXDdkHMYHHhyFflt8VwFKcsSGyjGhKTja5Zpe9JzNQDnpE8rtRFAR7A==", "1d961dd3-6022-4d97-93c7-e0083adafdf8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fe60605-1716-4010-abc6-ddacfd3ecf9b",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c4eec162-905c-43b3-b318-65f34b7bbe64", "buddyguardapp@outlook.com", "BUDDYGUARDAPP@OUTLOOK.COM", "ADMIN", "AQAAAAEAACcQAAAAEKa8FIX8RMn7HeCAp9C21gY90GEvCoz/ivZtjFFQV+ZcPzrusI+xfy99H4IfuzST6w==", "38428f1a-bc61-454d-9835-adc72726a8da" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3f107bb9-9810-4024-b4e3-182d696421ab",
                column: "ConcurrencyStamp",
                value: "b17e67d7-9301-4425-a4ca-f65b622f3405");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9e0143a5-0c68-4c92-92d5-34965e2ca95d",
                column: "ConcurrencyStamp",
                value: "8ea57a42-90bb-4d50-95ac-0f47f377b32d");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "307894cc-5f1e-4792-ae6b-40293f3dedb5",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "d6445b7c-6f41-49cd-920f-1e34e5d0ea9a", "hristo.velev98@gmail.com", null, null, "AQAAAAEAACcQAAAAEKPJle3U1n+0hRvD+ZUJ7POVgoX239Qu5fE1lMH0Je+7cM56W6VvSeZgJWxXnI2Tew==", "86323fe8-a1fd-4b22-86d4-22e9a190c2e1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7fe60605-1716-4010-abc6-ddacfd3ecf9b",
                columns: new[] { "ConcurrencyStamp", "Email", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b693376a-46f6-4b61-ab0d-191761c0028a", "hristo.velev98@gmail.com", null, null, "AQAAAAEAACcQAAAAED0PoaW/FRZOztz4vGLninvnb3eso531/rMUujRzKSavUMelcacO4VrYMawq0lM3ug==", "08f04de4-2ec8-4f67-ba9c-4a9bfb166a50" });
        }
    }
}

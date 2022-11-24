using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGuard.Core.Migrations
{
    public partial class UpdatedRequestTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Requests",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RequestSentDate",
                table: "Requests",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Requests");

            migrationBuilder.DropColumn(
                name: "RequestSentDate",
                table: "Requests");
        }
    }
}

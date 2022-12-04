using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BuddyGuard.Core.Migrations
{
    public partial class AddedColumnToRequest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Requests",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m); }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Requests");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace simple_Forum.Migrations
{
    public partial class RoleUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAdmin",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.AddColumn<bool>(
                name: "IsAdmin",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

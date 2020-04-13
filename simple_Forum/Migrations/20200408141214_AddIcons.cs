using Microsoft.EntityFrameworkCore.Migrations;

namespace simple_Forum.Migrations
{
    public partial class AddIcons : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "icon",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "icon",
                table: "User");
        }
    }
}

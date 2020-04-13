using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace simple_Forum.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(nullable: false),
                    password = table.Column<string>(nullable: false),
                    token = table.Column<string>(nullable: false),
                    reg_date = table.Column<DateTime>(nullable: false),
                    IsLoggedNow = table.Column<bool>(nullable: false),
                    IsAdmin = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(nullable: false),
                    text = table.Column<string>(nullable: true),
                    createDate = table.Column<DateTime>(nullable: false),
                    Authorid = table.Column<long>(nullable: false),
                    categoryid = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.id);
                    table.ForeignKey(
                        name: "FK_Post_User_Authorid",
                        column: x => x.Authorid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Post_Category_categoryid",
                        column: x => x.categoryid,
                        principalTable: "Category",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Discuss",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    text = table.Column<string>(nullable: false),
                    Authorid = table.Column<long>(nullable: false),
                    postIdnum = table.Column<long>(nullable: false),
                    pubdate = table.Column<DateTime>(nullable: false),
                    Postid = table.Column<long>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Discuss", x => x.id);
                    table.ForeignKey(
                        name: "FK_Discuss_User_Authorid",
                        column: x => x.Authorid,
                        principalTable: "User",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Discuss_Post_Postid",
                        column: x => x.Postid,
                        principalTable: "Post",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Discuss_Authorid",
                table: "Discuss",
                column: "Authorid");

            migrationBuilder.CreateIndex(
                name: "IX_Discuss_Postid",
                table: "Discuss",
                column: "Postid");

            migrationBuilder.CreateIndex(
                name: "IX_Post_Authorid",
                table: "Post",
                column: "Authorid");

            migrationBuilder.CreateIndex(
                name: "IX_Post_categoryid",
                table: "Post",
                column: "categoryid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Discuss");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}

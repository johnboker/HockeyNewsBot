using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HockeyNewsBot.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    ArticleId = table.Column<string>(nullable: false),
                    UuId = table.Column<string>(nullable: true),
                    Headline = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    PublishedOn = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.ArticleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articles");
        }
    }
}

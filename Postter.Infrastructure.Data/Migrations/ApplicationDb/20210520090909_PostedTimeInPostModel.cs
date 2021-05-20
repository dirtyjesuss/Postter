using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Postter.Infrastructure.Data.Migrations.ApplicationDb
{
    public partial class PostedTimeInPostModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "PostedTime",
                table: "Posts",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostedTime",
                table: "Posts");
        }
    }
}

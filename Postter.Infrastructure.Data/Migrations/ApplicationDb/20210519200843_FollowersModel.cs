using Microsoft.EntityFrameworkCore.Migrations;

namespace Postter.Infrastructure.Data.Migrations.ApplicationDb
{
    public partial class FollowersModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Follower",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "text", nullable: false),
                    FollowsId = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Follower", x => new { x.UserId, x.FollowsId });
                    table.ForeignKey(
                        name: "FK_Follower_AspNetUsers_FollowsId",
                        column: x => x.FollowsId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Follower_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Follower_FollowsId",
                table: "Follower",
                column: "FollowsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Follower");
        }
    }
}

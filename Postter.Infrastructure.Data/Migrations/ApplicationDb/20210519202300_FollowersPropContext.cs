using Microsoft.EntityFrameworkCore.Migrations;

namespace Postter.Infrastructure.Data.Migrations.ApplicationDb
{
    public partial class FollowersPropContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Follower_AspNetUsers_FollowsId",
                table: "Follower");

            migrationBuilder.DropForeignKey(
                name: "FK_Follower_AspNetUsers_UserId",
                table: "Follower");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Follower",
                table: "Follower");

            migrationBuilder.RenameTable(
                name: "Follower",
                newName: "Followers");

            migrationBuilder.RenameIndex(
                name: "IX_Follower_FollowsId",
                table: "Followers",
                newName: "IX_Followers_FollowsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Followers",
                table: "Followers",
                columns: new[] { "UserId", "FollowsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_AspNetUsers_FollowsId",
                table: "Followers",
                column: "FollowsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Followers_AspNetUsers_UserId",
                table: "Followers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Followers_AspNetUsers_FollowsId",
                table: "Followers");

            migrationBuilder.DropForeignKey(
                name: "FK_Followers_AspNetUsers_UserId",
                table: "Followers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Followers",
                table: "Followers");

            migrationBuilder.RenameTable(
                name: "Followers",
                newName: "Follower");

            migrationBuilder.RenameIndex(
                name: "IX_Followers_FollowsId",
                table: "Follower",
                newName: "IX_Follower_FollowsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Follower",
                table: "Follower",
                columns: new[] { "UserId", "FollowsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_AspNetUsers_FollowsId",
                table: "Follower",
                column: "FollowsId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Follower_AspNetUsers_UserId",
                table: "Follower",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

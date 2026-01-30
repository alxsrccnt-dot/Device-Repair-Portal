using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserChangeHistory_AspNetUsers_UserId",
                table: "UserChangeHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_UserDetails_AspNetUsers_UserId",
                table: "UserDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserChangeHistory",
                table: "UserChangeHistory");

            migrationBuilder.RenameTable(
                name: "UserDetails",
                newName: "UsersDetails");

            migrationBuilder.RenameTable(
                name: "UserChangeHistory",
                newName: "UsersChangeHistory");

            migrationBuilder.RenameIndex(
                name: "IX_UserDetails_UserId",
                table: "UsersDetails",
                newName: "IX_UsersDetails_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserChangeHistory_UserId",
                table: "UsersChangeHistory",
                newName: "IX_UsersChangeHistory_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersDetails",
                table: "UsersDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersChangeHistory",
                table: "UsersChangeHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersChangeHistory_AspNetUsers_UserId",
                table: "UsersChangeHistory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDetails_AspNetUsers_UserId",
                table: "UsersDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersChangeHistory_AspNetUsers_UserId",
                table: "UsersChangeHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersDetails_AspNetUsers_UserId",
                table: "UsersDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersDetails",
                table: "UsersDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersChangeHistory",
                table: "UsersChangeHistory");

            migrationBuilder.RenameTable(
                name: "UsersDetails",
                newName: "UserDetails");

            migrationBuilder.RenameTable(
                name: "UsersChangeHistory",
                newName: "UserChangeHistory");

            migrationBuilder.RenameIndex(
                name: "IX_UsersDetails_UserId",
                table: "UserDetails",
                newName: "IX_UserDetails_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_UsersChangeHistory_UserId",
                table: "UserChangeHistory",
                newName: "IX_UserChangeHistory_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserDetails",
                table: "UserDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserChangeHistory",
                table: "UserChangeHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserChangeHistory_AspNetUsers_UserId",
                table: "UserChangeHistory",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserDetails_AspNetUsers_UserId",
                table: "UserDetails",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

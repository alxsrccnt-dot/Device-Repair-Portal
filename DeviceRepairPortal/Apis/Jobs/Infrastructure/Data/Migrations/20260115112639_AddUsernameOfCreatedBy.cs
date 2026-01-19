using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUsernameOfCreatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsernameOfCreatedBy",
                table: "Tickets",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsernameOfCreatedBy",
                table: "Phases",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsernameOfCreatedBy",
                table: "Jobs",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsernameOfCreatedBy",
                table: "Investigations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsernameOfCreatedBy",
                table: "Discounts",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsernameOfCreatedBy",
                table: "Comments",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UsernameOfCreatedBy",
                table: "BillingInformations",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsernameOfCreatedBy",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "UsernameOfCreatedBy",
                table: "Phases");

            migrationBuilder.DropColumn(
                name: "UsernameOfCreatedBy",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "UsernameOfCreatedBy",
                table: "Investigations");

            migrationBuilder.DropColumn(
                name: "UsernameOfCreatedBy",
                table: "Discounts");

            migrationBuilder.DropColumn(
                name: "UsernameOfCreatedBy",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UsernameOfCreatedBy",
                table: "BillingInformations");
        }
    }
}

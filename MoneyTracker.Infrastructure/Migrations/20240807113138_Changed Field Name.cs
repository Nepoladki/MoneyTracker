using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedFieldName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file_path",
                table: "categories_users_icons");

            migrationBuilder.AddColumn<string>(
                name: "file_name",
                table: "categories_users_icons",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "file_name",
                table: "categories_users_icons");

            migrationBuilder.AddColumn<string>(
                name: "file_path",
                table: "categories_users_icons",
                type: "text",
                nullable: true);
        }
    }
}

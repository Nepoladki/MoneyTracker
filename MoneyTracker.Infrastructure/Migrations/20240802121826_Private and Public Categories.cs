using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PrivateandPublicCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "created_by_user_id",
                table: "categories",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<bool>(
                name: "is_public",
                table: "categories",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateIndex(
                name: "ix_categories_category_name_created_by_user_id",
                table: "categories",
                columns: new[] { "category_name", "created_by_user_id" },
                unique: true,
                filter: "is_public = FALSE");

            migrationBuilder.CreateIndex(
                name: "ix_categories_category_name_is_public",
                table: "categories",
                columns: new[] { "category_name", "is_public" },
                unique: true,
                filter: "is_public = TRUE");

            migrationBuilder.CreateIndex(
                name: "ix_categories_created_by_user_id",
                table: "categories",
                column: "created_by_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_categories_users_created_by_user_id",
                table: "categories",
                column: "created_by_user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_categories_users_created_by_user_id",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "ix_categories_category_name_created_by_user_id",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "ix_categories_category_name_is_public",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "ix_categories_created_by_user_id",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "created_by_user_id",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "is_public",
                table: "categories");
        }
    }
}

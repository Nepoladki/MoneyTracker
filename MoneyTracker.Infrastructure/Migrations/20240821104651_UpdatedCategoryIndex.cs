using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedCategoryIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_categories_category_name_created_by_user_id",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "ix_categories_category_name_is_public",
                table: "categories");

            migrationBuilder.CreateIndex(
                name: "ix_categories_category_name_created_by_user_id_category_type",
                table: "categories",
                columns: new[] { "category_name", "created_by_user_id", "category_type" },
                unique: true,
                filter: "is_public = FALSE");

            migrationBuilder.CreateIndex(
                name: "ix_categories_category_name_is_public_category_type",
                table: "categories",
                columns: new[] { "category_name", "is_public", "category_type" },
                unique: true,
                filter: "is_public = TRUE");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_categories_category_name_created_by_user_id_category_type",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "ix_categories_category_name_is_public_category_type",
                table: "categories");

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
        }
    }
}

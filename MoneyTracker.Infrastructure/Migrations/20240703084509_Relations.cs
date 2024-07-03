using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MoneyTracker.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_transactions_category_id",
                table: "transactions",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "ix_transactions_user_id",
                table: "transactions",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_transactions_categories_category_id",
                table: "transactions",
                column: "category_id",
                principalTable: "categories",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_transactions_users_user_id",
                table: "transactions",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_transactions_categories_category_id",
                table: "transactions");

            migrationBuilder.DropForeignKey(
                name: "fk_transactions_users_user_id",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "ix_transactions_category_id",
                table: "transactions");

            migrationBuilder.DropIndex(
                name: "ix_transactions_user_id",
                table: "transactions");
        }
    }
}

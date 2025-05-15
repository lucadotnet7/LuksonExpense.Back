using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LuksonExpense.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class change_column_name_for_budgets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FromTo",
                table: "Budgets",
                newName: "ToDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ToDate",
                table: "Budgets",
                newName: "FromTo");
        }
    }
}

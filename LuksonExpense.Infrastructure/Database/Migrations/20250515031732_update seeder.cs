using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LuksonExpense.Infrastructure.Database.Migrations
{
    /// <inheritdoc />
    public partial class updateseeder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modules",
                columns: new[] { "Id", "Description", "IconName", "Name", "Route" },
                values: new object[,]
                {
                    { 2, "Sección donde se administran los presupuestos.", "AccountBalanceWalletIcon", "Presupuestos", "/budgets" },
                    { 3, "Sección donde se administran los gastos", "CompareArrowsIcon", "Gastos", "/expenses" },
                    { 4, "Sección donde se administran las categorías", "AutoAwesomeMosaicIcon", "Categorías", "/categories" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Modules",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

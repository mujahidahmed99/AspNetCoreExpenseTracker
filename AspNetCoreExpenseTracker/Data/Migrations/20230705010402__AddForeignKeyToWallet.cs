using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreExpenseTracker.Data.Migrations
{
    public partial class _AddForeignKeyToWallet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Wallets_CurrencyId",
                table: "Wallets",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Wallets_Currencies_CurrencyId",
                table: "Wallets",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wallets_Currencies_CurrencyId",
                table: "Wallets");

            migrationBuilder.DropIndex(
                name: "IX_Wallets_CurrencyId",
                table: "Wallets");
        }
    }
}

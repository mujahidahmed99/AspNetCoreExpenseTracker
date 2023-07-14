using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AspNetCoreExpenseTracker.Data.Migrations
{
    public partial class _UpdateTransactionCommentsColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                table: "Transactions",
                newName: "Date");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Transactions",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Transactions",
                newName: "date");

            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "Transactions",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}

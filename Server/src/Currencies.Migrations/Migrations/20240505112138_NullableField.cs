using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Currencies.Migrations.Migrations
{
    public partial class NullableField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExchangeHistories_ExchangeRate_RateID",
                table: "UserExchangeHistories");

            migrationBuilder.AlterColumn<int>(
                name: "RateID",
                table: "UserExchangeHistories",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExchangeHistories_ExchangeRate_RateID",
                table: "UserExchangeHistories",
                column: "RateID",
                principalTable: "ExchangeRate",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExchangeHistories_ExchangeRate_RateID",
                table: "UserExchangeHistories");

            migrationBuilder.AlterColumn<int>(
                name: "RateID",
                table: "UserExchangeHistories",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExchangeHistories_ExchangeRate_RateID",
                table: "UserExchangeHistories",
                column: "RateID",
                principalTable: "ExchangeRate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

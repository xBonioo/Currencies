using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Currencies.Migrations.Migrations
{
    public partial class updateExchangeHistories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExchangeHistories_Currencies_FromCurrencyID",
                table: "UserExchangeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExchangeHistories_Currencies_ToCurrencyID",
                table: "UserExchangeHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserExchangeHistories_FromCurrencyID",
                table: "UserExchangeHistories");

            migrationBuilder.DropColumn(
                name: "ExchangeRate",
                table: "UserExchangeHistories");

            migrationBuilder.RenameColumn(
                name: "ToCurrencyID",
                table: "UserExchangeHistories",
                newName: "RateID");

            migrationBuilder.RenameColumn(
                name: "FromCurrencyID",
                table: "UserExchangeHistories",
                newName: "PaymentType");

            migrationBuilder.RenameIndex(
                name: "IX_UserExchangeHistories_ToCurrencyID",
                table: "UserExchangeHistories",
                newName: "IX_UserExchangeHistories_RateID");

            migrationBuilder.AddColumn<int>(
                name: "AccountID",
                table: "UserExchangeHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ExchangeTime",
                table: "UserExchangeHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "UserExchangeHistories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatus",
                table: "UserExchangeHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserExchangeHistories_AccountID",
                table: "UserExchangeHistories",
                column: "AccountID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExchangeHistories_ExchangeRate_RateID",
                table: "UserExchangeHistories",
                column: "RateID",
                principalTable: "ExchangeRate",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExchangeHistories_UserCurrencyAmounts_AccountID",
                table: "UserExchangeHistories",
                column: "AccountID",
                principalTable: "UserCurrencyAmounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserExchangeHistories_ExchangeRate_RateID",
                table: "UserExchangeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserExchangeHistories_UserCurrencyAmounts_AccountID",
                table: "UserExchangeHistories");

            migrationBuilder.DropIndex(
                name: "IX_UserExchangeHistories_AccountID",
                table: "UserExchangeHistories");

            migrationBuilder.DropColumn(
                name: "AccountID",
                table: "UserExchangeHistories");

            migrationBuilder.DropColumn(
                name: "ExchangeTime",
                table: "UserExchangeHistories");

            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "UserExchangeHistories");

            migrationBuilder.DropColumn(
                name: "PaymentStatus",
                table: "UserExchangeHistories");

            migrationBuilder.RenameColumn(
                name: "RateID",
                table: "UserExchangeHistories",
                newName: "ToCurrencyID");

            migrationBuilder.RenameColumn(
                name: "PaymentType",
                table: "UserExchangeHistories",
                newName: "FromCurrencyID");

            migrationBuilder.RenameIndex(
                name: "IX_UserExchangeHistories_RateID",
                table: "UserExchangeHistories",
                newName: "IX_UserExchangeHistories_ToCurrencyID");

            migrationBuilder.AddColumn<decimal>(
                name: "ExchangeRate",
                table: "UserExchangeHistories",
                type: "decimal(18,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateIndex(
                name: "IX_UserExchangeHistories_FromCurrencyID",
                table: "UserExchangeHistories",
                column: "FromCurrencyID");

            migrationBuilder.AddForeignKey(
                name: "FK_UserExchangeHistories_Currencies_FromCurrencyID",
                table: "UserExchangeHistories",
                column: "FromCurrencyID",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserExchangeHistories_Currencies_ToCurrencyID",
                table: "UserExchangeHistories",
                column: "ToCurrencyID",
                principalTable: "Currencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

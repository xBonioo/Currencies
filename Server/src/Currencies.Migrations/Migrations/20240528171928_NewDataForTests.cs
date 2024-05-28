using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Currencies.Migrations.Migrations
{
    public partial class NewDataForTests : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Adres", "ConcurrencyStamp", "CreatedOn", "Email", "EmailConfirmed", "FirstName", "IDExpiryDate", "IDIssueDate", "IDNumber", "IdentityNumber", "IsActive", "LockoutEnabled", "LockoutEnd", "ModifiedOn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RoleId", "SecondName", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "679381f2-06a1-4e22-beda-179e8e9e3236", 0, "Warszawa,", "885570d9-fb00-496a-8abd-34d0ba7d9c76", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "test1@mail.com", false, null, new DateTime(2030, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "EZ12345", 997, true, false, null, null, "TEST1@MAIL.COM", "TESTUSER1", "AQAAAAEAACcQAAAAEIR44hzbnj/pCIqsHG4vIPm/ARO5F+qPlxQp9Wjhn+EBi/q73B+RlmXZNV+yUOvgPQ==", null, false, 1, null, "4466d9e6-1d1e-4d0e-b08b-22e5cbb2d8dd", false, "TestUser1" });

            migrationBuilder.InsertData(
                table: "ExchangeRate",
                columns: new[] { "Id", "CreatedOn", "Direction", "FromCurrencyID", "IsActive", "ModifiedOn", "Rate", "ToCurrencyID" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 4, true, null, 4m, 1 });

            migrationBuilder.InsertData(
                table: "UserCurrencyAmounts",
                columns: new[] { "Id", "Amount", "CreatedOn", "CurrencyId", "IsActive", "ModifiedOn", "UserId" },
                values: new object[] { 1, 100m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, true, null, "679381f2-06a1-4e22-beda-179e8e9e3236" });

            migrationBuilder.InsertData(
                table: "UserExchangeHistories",
                columns: new[] { "Id", "AccountID", "Amount", "CreatedOn", "PaymentStatus", "PaymentType", "RateID", "UserID" },
                values: new object[] { 1, 1, 20m, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, 0, 1, "679381f2-06a1-4e22-beda-179e8e9e3236" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserExchangeHistories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ExchangeRate",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "UserCurrencyAmounts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "679381f2-06a1-4e22-beda-179e8e9e3236");
        }
    }
}

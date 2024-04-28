using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Currencies.Migrations.Migrations
{
    public partial class updateExchangeRate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Direction",
                table: "ExchangeRate",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "ExchangeRate",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Direction",
                table: "ExchangeRate");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ExchangeRate");
        }
    }
}

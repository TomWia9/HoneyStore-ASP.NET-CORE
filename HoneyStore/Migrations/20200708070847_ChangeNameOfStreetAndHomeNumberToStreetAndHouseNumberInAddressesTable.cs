using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneyStore.Migrations
{
    public partial class ChangeNameOfStreetAndHomeNumberToStreetAndHouseNumberInAddressesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetAndHomeNumber",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "StreetAndHouseNumber",
                table: "Address",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StreetAndHouseNumber",
                table: "Address");

            migrationBuilder.AddColumn<string>(
                name: "StreetAndHomeNumber",
                table: "Address",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");
        }
    }
}

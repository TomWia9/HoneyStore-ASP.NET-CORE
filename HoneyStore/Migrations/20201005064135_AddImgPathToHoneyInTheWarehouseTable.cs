using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneyStore.Migrations
{
    public partial class AddImgPathToHoneyInTheWarehouseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImgPath",
                table: "HoneysInTheWarehouse",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgPath",
                table: "HoneysInTheWarehouse");
        }
    }
}

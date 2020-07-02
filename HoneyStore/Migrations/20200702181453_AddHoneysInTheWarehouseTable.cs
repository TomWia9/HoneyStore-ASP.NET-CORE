using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneyStore.Migrations
{
    public partial class AddHoneysInTheWarehouseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HoneysInTheWarehouse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 4)", maxLength: 10, nullable: false),
                    Amount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoneysInTheWarehouse", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoneysInTheWarehouse");
        }
    }
}

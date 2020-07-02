using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneyStore.Migrations
{
    public partial class AddCartAndHoneyItemsTablesAndRelationsBetweenClientAndCartAndCartAndHoneyItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Carts_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HoneyItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 4)", maxLength: 10, nullable: false),
                    CartId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HoneyItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HoneyItem_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ClientId",
                table: "Carts",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HoneyItem_CartId",
                table: "HoneyItem",
                column: "CartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HoneyItem");

            migrationBuilder.DropTable(
                name: "Carts");
        }
    }
}

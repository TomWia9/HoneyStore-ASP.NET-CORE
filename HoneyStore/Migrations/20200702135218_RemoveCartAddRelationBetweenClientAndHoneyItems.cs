using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneyStore.Migrations
{
    public partial class RemoveCartAddRelationBetweenClientAndHoneyItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneysInTheCart_Carts_CartId",
                table: "HoneysInTheCart");

            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.DropIndex(
                name: "IX_HoneysInTheCart_CartId",
                table: "HoneysInTheCart");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "HoneysInTheCart");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "HoneysInTheCart",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_HoneysInTheCart_ClientId",
                table: "HoneysInTheCart",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_HoneysInTheCart_Clients_ClientId",
                table: "HoneysInTheCart",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneysInTheCart_Clients_ClientId",
                table: "HoneysInTheCart");

            migrationBuilder.DropIndex(
                name: "IX_HoneysInTheCart_ClientId",
                table: "HoneysInTheCart");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "HoneysInTheCart");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "HoneysInTheCart",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_HoneysInTheCart_CartId",
                table: "HoneysInTheCart",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_ClientId",
                table: "Carts",
                column: "ClientId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_HoneysInTheCart_Carts_CartId",
                table: "HoneysInTheCart",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace HoneyStore.Migrations
{
    public partial class ChangeNameOfHoneyItemTableToHoneysInTheCart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneyItem_Carts_CartId",
                table: "HoneyItem");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoneyItem",
                table: "HoneyItem");

            migrationBuilder.RenameTable(
                name: "HoneyItem",
                newName: "HoneysInTheCart");

            migrationBuilder.RenameIndex(
                name: "IX_HoneyItem_CartId",
                table: "HoneysInTheCart",
                newName: "IX_HoneysInTheCart_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoneysInTheCart",
                table: "HoneysInTheCart",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoneysInTheCart_Carts_CartId",
                table: "HoneysInTheCart",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HoneysInTheCart_Carts_CartId",
                table: "HoneysInTheCart");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HoneysInTheCart",
                table: "HoneysInTheCart");

            migrationBuilder.RenameTable(
                name: "HoneysInTheCart",
                newName: "HoneyItem");

            migrationBuilder.RenameIndex(
                name: "IX_HoneysInTheCart_CartId",
                table: "HoneyItem",
                newName: "IX_HoneyItem_CartId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HoneyItem",
                table: "HoneyItem",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_HoneyItem_Carts_CartId",
                table: "HoneyItem",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

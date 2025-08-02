using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datass.Migrations
{
    /// <inheritdoc />
    public partial class FixEntityRelationships : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderIdOrder",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Users_UserIdUser",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_UserIdUser",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_OrderIdOrder",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "UserIdUser",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "OrderIdOrder",
                table: "OrderDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserIdUser",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderIdOrder",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserIdUser",
                table: "Orders",
                column: "UserIdUser");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderIdOrder",
                table: "OrderDetails",
                column: "OrderIdOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderIdOrder",
                table: "OrderDetails",
                column: "OrderIdOrder",
                principalTable: "Orders",
                principalColumn: "IdOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Users_UserIdUser",
                table: "Orders",
                column: "UserIdUser",
                principalTable: "Users",
                principalColumn: "IdUser");
        }
    }
}

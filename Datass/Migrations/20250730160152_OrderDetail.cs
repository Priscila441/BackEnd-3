using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Datass.Migrations
{
    /// <inheritdoc />
    public partial class OrderDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "stateOrder",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "CartID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "OrderDetails",
                columns: table => new
                {
                    IdOrderDetail = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    OrderIdOrder = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetails", x => x.IdOrderDetail);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "IdOrder",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderDetails_Orders_OrderIdOrder",
                        column: x => x.OrderIdOrder,
                        principalTable: "Orders",
                        principalColumn: "IdOrder");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CartID",
                table: "Orders",
                column: "CartID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderId",
                table: "OrderDetails",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_OrderIdOrder",
                table: "OrderDetails",
                column: "OrderIdOrder");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Carts_CartID",
                table: "Orders",
                column: "CartID",
                principalTable: "Carts",
                principalColumn: "IdCart",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Carts_CartID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CartID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CartID",
                table: "Orders");

            migrationBuilder.AlterColumn<int>(
                name: "stateOrder",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza_Delievery_System.Migrations
{
    /// <inheritdoc />
    public partial class drop_Topping : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomPizza_Topping_ToppingID",
                table: "CustomPizza");

            migrationBuilder.DropTable(
                name: "Topping");

            migrationBuilder.DropIndex(
                name: "IX_CustomPizza_ToppingID",
                table: "CustomPizza");

            migrationBuilder.DropColumn(
                name: "ToppingID",
                table: "CustomPizza");

            migrationBuilder.AddColumn<string>(
                name: "Topping",
                table: "CustomPizza",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Topping",
                table: "CustomPizza");

            migrationBuilder.AddColumn<int>(
                name: "ToppingID",
                table: "CustomPizza",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Topping",
                columns: table => new
                {
                    ToppingID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAvailable = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LowStockThreshold = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topping", x => x.ToppingID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomPizza_ToppingID",
                table: "CustomPizza",
                column: "ToppingID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomPizza_Topping_ToppingID",
                table: "CustomPizza",
                column: "ToppingID",
                principalTable: "Topping",
                principalColumn: "ToppingID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza_Delievery_System.Migrations
{
    /// <inheritdoc />
    public partial class CustomPizzaToppingFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateIndex(
                name: "IX_CustomPizza_ToppingID",
                table: "CustomPizza",
                column: "ToppingID");

            migrationBuilder.AddForeignKey(
                name: "FK_CustomPizza_Toppings_ToppingID",
                table: "CustomPizza",
                column: "ToppingID",
                principalTable: "Toppings",
                principalColumn: "ToppingID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CustomPizza_Toppings_ToppingID",
                table: "CustomPizza");

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
    }
}

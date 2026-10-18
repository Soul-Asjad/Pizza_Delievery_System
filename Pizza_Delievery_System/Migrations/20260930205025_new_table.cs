using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza_Delievery_System.Migrations
{
    /// <inheritdoc />
    public partial class new_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizza_Deals",
                columns: table => new
                {
                    DealID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Isactive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizza_Deals", x => x.DealID);
                });

            migrationBuilder.CreateTable(
                name: "DealPizza",
                columns: table => new
                {
                    DealPizzaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DealID = table.Column<int>(type: "int", nullable: false),
                    PizzaID = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealPizza", x => x.DealPizzaID);
                    table.ForeignKey(
                        name: "FK_DealPizza_Pizza_Deals_DealID",
                        column: x => x.DealID,
                        principalTable: "Pizza_Deals",
                        principalColumn: "DealID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DealPizza_Pizza_PizzaID",
                        column: x => x.PizzaID,
                        principalTable: "Pizza",
                        principalColumn: "PizzaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DealPizza_DealID",
                table: "DealPizza",
                column: "DealID");

            migrationBuilder.CreateIndex(
                name: "IX_DealPizza_PizzaID",
                table: "DealPizza",
                column: "PizzaID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DealPizza");

            migrationBuilder.DropTable(
                name: "Pizza_Deals");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerMate.DbContext.Migrations
{
    public partial class RemoveOrderRecipesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderRecipe",
                schema: "BKM");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 16, 11, 45, 20, 116, DateTimeKind.Local).AddTicks(5386),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 21, 21, 8, 44, 842, DateTimeKind.Local).AddTicks(2856));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 21, 21, 8, 44, 842, DateTimeKind.Local).AddTicks(2856),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 12, 16, 11, 45, 20, 116, DateTimeKind.Local).AddTicks(5386));

            migrationBuilder.CreateTable(
                name: "OrderRecipe",
                schema: "BKM",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false),
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRecipe", x => new { x.OrderId, x.RecipeId });
                    table.ForeignKey(
                        name: "FK_OrderRecipe_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "BKM",
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderRecipe_Recipe_RecipeId",
                        column: x => x.RecipeId,
                        principalSchema: "BKM",
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderRecipe_RecipeId",
                schema: "BKM",
                table: "OrderRecipe",
                column: "RecipeId");
        }
    }
}

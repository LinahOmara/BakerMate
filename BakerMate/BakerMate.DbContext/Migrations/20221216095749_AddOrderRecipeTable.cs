using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerMate.DbContext.Migrations
{
    public partial class AddOrderRecipeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 16, 11, 57, 49, 483, DateTimeKind.Local).AddTicks(9161),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 12, 16, 11, 45, 20, 116, DateTimeKind.Local).AddTicks(5386));

            migrationBuilder.CreateTable(
                name: "OrderRecipe",
                columns: table => new
                {
                    RecipeBaseCountId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderRecipe", x => new { x.RecipeBaseCountId, x.OrderId });
                    table.ForeignKey(
                        name: "FK_OrderRecipe_Order_OrderId",
                        column: x => x.OrderId,
                        principalSchema: "BKM",
                        principalTable: "Order",
                        principalColumn: "OrderId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderRecipe_RecipeBaseCount_RecipeBaseCountId",
                        column: x => x.RecipeBaseCountId,
                        principalSchema: "BKM",
                        principalTable: "RecipeBaseCount",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderRecipe_OrderId",
                table: "OrderRecipe",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderRecipe");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 16, 11, 45, 20, 116, DateTimeKind.Local).AddTicks(5386),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 12, 16, 11, 57, 49, 483, DateTimeKind.Local).AddTicks(9161));
        }
    }
}

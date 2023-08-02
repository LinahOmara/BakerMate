using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerMate.DbContext.Migrations
{
    public partial class AddingUnitOfMeasureToRecipeIngredient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitOfMeasureId",
                schema: "BKM",
                table: "RecipeIngredient",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 2, 21, 31, 38, 395, DateTimeKind.Local).AddTicks(2065),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 12, 16, 11, 57, 49, 483, DateTimeKind.Local).AddTicks(9161));

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_UnitOfMeasureId",
                schema: "BKM",
                table: "RecipeIngredient",
                column: "UnitOfMeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipeIngredient_UnitOfMeasure_UnitOfMeasureId",
                schema: "BKM",
                table: "RecipeIngredient",
                column: "UnitOfMeasureId",
                principalTable: "UnitOfMeasure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipeIngredient_UnitOfMeasure_UnitOfMeasureId",
                schema: "BKM",
                table: "RecipeIngredient");

            migrationBuilder.DropIndex(
                name: "IX_RecipeIngredient_UnitOfMeasureId",
                schema: "BKM",
                table: "RecipeIngredient");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasureId",
                schema: "BKM",
                table: "RecipeIngredient");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 12, 16, 11, 57, 49, 483, DateTimeKind.Local).AddTicks(9161),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 8, 2, 21, 31, 38, 395, DateTimeKind.Local).AddTicks(2065));
        }
    }
}

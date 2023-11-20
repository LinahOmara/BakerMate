using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerMate.DbContext.Migrations
{
    public partial class Add_Count_OrderRecipeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cost",
                schema: "BKM",
                table: "Order",
                newName: "Price");

            migrationBuilder.AddColumn<int>(
                name: "Count",
                table: "OrderRecipe",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 16, 23, 9, 35, 814, DateTimeKind.Local).AddTicks(5975),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 8, 2, 21, 31, 38, 395, DateTimeKind.Local).AddTicks(2065));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Count",
                table: "OrderRecipe");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "BKM",
                table: "Order",
                newName: "Cost");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 2, 21, 31, 38, 395, DateTimeKind.Local).AddTicks(2065),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 8, 16, 23, 9, 35, 814, DateTimeKind.Local).AddTicks(5975));
        }
    }
}

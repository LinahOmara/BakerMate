using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerMate.DbContext.Migrations
{
    public partial class AddingSize_RecipeSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "size",
                schema: "BKM",
                table: "RecipeSize",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 31, 23, 48, 51, 353, DateTimeKind.Local).AddTicks(8979),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 26, 14, 51, 30, 47, DateTimeKind.Local).AddTicks(8951));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "size",
                schema: "BKM",
                table: "RecipeSize");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 26, 14, 51, 30, 47, DateTimeKind.Local).AddTicks(8951),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 31, 23, 48, 51, 353, DateTimeKind.Local).AddTicks(8979));
        }
    }
}

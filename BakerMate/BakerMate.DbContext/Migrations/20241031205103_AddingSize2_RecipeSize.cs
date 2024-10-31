using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerMate.DbContext.Migrations
{
    public partial class AddingSize2_RecipeSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "size",
                schema: "BKM",
                table: "RecipeSize",
                newName: "Size");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 31, 23, 51, 3, 315, DateTimeKind.Local).AddTicks(2502),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 31, 23, 48, 51, 353, DateTimeKind.Local).AddTicks(8979));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Size",
                schema: "BKM",
                table: "RecipeSize",
                newName: "size");

            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 10, 31, 23, 48, 51, 353, DateTimeKind.Local).AddTicks(8979),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 10, 31, 23, 51, 3, 315, DateTimeKind.Local).AddTicks(2502));
        }
    }
}

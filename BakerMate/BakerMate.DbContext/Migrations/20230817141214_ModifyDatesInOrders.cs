using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerMate.DbContext.Migrations
{
    public partial class ModifyDatesInOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 8, 16, 23, 9, 35, 814, DateTimeKind.Local).AddTicks(5975));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 8, 16, 23, 9, 35, 814, DateTimeKind.Local).AddTicks(5975),
                oldClrType: typeof(DateOnly),
                oldType: "TEXT",
                oldDefaultValue: new DateOnly(1, 1, 1));
        }
    }
}

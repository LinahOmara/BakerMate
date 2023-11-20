using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerMate.DbContext.Migrations
{
    public partial class OrderDatesTobeDateTime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2023, 11, 20, 20, 4, 55, 177, DateTimeKind.Local).AddTicks(8392),
                oldClrType: typeof(DateOnly),
                oldType: "TEXT",
                oldDefaultValue: new DateOnly(2023, 8, 17));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(2023, 8, 17),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2023, 11, 20, 20, 4, 55, 177, DateTimeKind.Local).AddTicks(8392));
        }
    }
}

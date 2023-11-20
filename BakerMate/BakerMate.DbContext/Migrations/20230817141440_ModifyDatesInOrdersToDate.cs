using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerMate.DbContext.Migrations
{
    public partial class ModifyDatesInOrdersToDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(2023, 8, 17),
                oldClrType: typeof(DateOnly),
                oldType: "TEXT",
                oldDefaultValue: new DateOnly(1, 1, 1));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "OrderingDate",
                schema: "BKM",
                table: "Order",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1),
                oldClrType: typeof(DateOnly),
                oldType: "TEXT",
                oldDefaultValue: new DateOnly(2023, 8, 17));
        }
    }
}

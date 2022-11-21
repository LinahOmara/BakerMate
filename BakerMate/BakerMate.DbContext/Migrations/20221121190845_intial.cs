using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BakerMate.DbContext.Migrations
{
    public partial class intial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BKM");

            migrationBuilder.CreateTable(
                name: "Category",
                schema: "BKM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "BKM",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Customer = table.Column<string>(type: "TEXT", nullable: false),
                    CustomerNumber = table.Column<string>(type: "TEXT", nullable: false),
                    OrderDescription = table.Column<string>(type: "TEXT", nullable: false),
                    OrderingDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2022, 11, 21, 21, 8, 44, 842, DateTimeKind.Local).AddTicks(2856)),
                    DeliveryDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Delivered = table.Column<bool>(type: "INTEGER", nullable: false),
                    Cost = table.Column<double>(type: "REAL", nullable: false),
                    Revenue = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderId);
                });

            migrationBuilder.CreateTable(
                name: "UnitOfMeasure",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitOfMeasure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredient",
                schema: "BKM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    PurchaceLocation = table.Column<string>(type: "TEXT", nullable: false),
                    UnitOfMeasureId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredient", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredient_UnitOfMeasure_UnitOfMeasureId",
                        column: x => x.UnitOfMeasureId,
                        principalTable: "UnitOfMeasure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Recipe",
                schema: "BKM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BaseIngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Recipe_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalSchema: "BKM",
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recipe_Ingredient_BaseIngredientId",
                        column: x => x.BaseIngredientId,
                        principalSchema: "BKM",
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderRecipe",
                schema: "BKM",
                columns: table => new
                {
                    RecipeId = table.Column<int>(type: "INTEGER", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "RecipeBaseCount",
                schema: "BKM",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RecipieId = table.Column<int>(type: "INTEGER", nullable: false),
                    BaseCount = table.Column<double>(type: "REAL", nullable: false),
                    Size = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeBaseCount", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RecipeBaseCount_Recipe_RecipieId",
                        column: x => x.RecipieId,
                        principalSchema: "BKM",
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RecipeIngredient",
                schema: "BKM",
                columns: table => new
                {
                    RecipieId = table.Column<int>(type: "INTEGER", nullable: false),
                    IngredientId = table.Column<int>(type: "INTEGER", nullable: false),
                    IngredientQuantity = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeIngredient", x => new { x.IngredientId, x.RecipieId });
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Ingredient_IngredientId",
                        column: x => x.IngredientId,
                        principalSchema: "BKM",
                        principalTable: "Ingredient",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RecipeIngredient_Recipe_RecipieId",
                        column: x => x.RecipieId,
                        principalSchema: "BKM",
                        principalTable: "Recipe",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ingredient_UnitOfMeasureId",
                schema: "BKM",
                table: "Ingredient",
                column: "UnitOfMeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderRecipe_RecipeId",
                schema: "BKM",
                table: "OrderRecipe",
                column: "RecipeId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_BaseIngredientId",
                schema: "BKM",
                table: "Recipe",
                column: "BaseIngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_CategoryId",
                schema: "BKM",
                table: "Recipe",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeBaseCount_RecipieId",
                schema: "BKM",
                table: "RecipeBaseCount",
                column: "RecipieId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipeIngredient_RecipieId",
                schema: "BKM",
                table: "RecipeIngredient",
                column: "RecipieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderRecipe",
                schema: "BKM");

            migrationBuilder.DropTable(
                name: "RecipeBaseCount",
                schema: "BKM");

            migrationBuilder.DropTable(
                name: "RecipeIngredient",
                schema: "BKM");

            migrationBuilder.DropTable(
                name: "Order",
                schema: "BKM");

            migrationBuilder.DropTable(
                name: "Recipe",
                schema: "BKM");

            migrationBuilder.DropTable(
                name: "Category",
                schema: "BKM");

            migrationBuilder.DropTable(
                name: "Ingredient",
                schema: "BKM");

            migrationBuilder.DropTable(
                name: "UnitOfMeasure");
        }
    }
}

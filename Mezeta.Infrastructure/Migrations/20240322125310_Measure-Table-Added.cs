using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mezeta.Infrastructure.Migrations
{
    public partial class MeasureTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UnitOfMeasure",
                table: "RecipesSpices");

            migrationBuilder.DropColumn(
                name: "UnitOfMeasure",
                table: "RecipesIngredients");

            migrationBuilder.AddColumn<int>(
                name: "MeasureId",
                table: "RecipesSpices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MeasureId",
                table: "RecipesIngredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Measures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Measures", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Measures",
                columns: new[] { "Id", "Unit" },
                values: new object[] { 1, "g" });

            migrationBuilder.InsertData(
                table: "Measures",
                columns: new[] { "Id", "Unit" },
                values: new object[] { 2, "kg" });

            migrationBuilder.InsertData(
                table: "Measures",
                columns: new[] { "Id", "Unit" },
                values: new object[] { 3, "ml" });

            migrationBuilder.UpdateData(
                table: "RecipesIngredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "MeasureId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipesIngredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "MeasureId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipesSpices",
                keyColumn: "Id",
                keyValue: 1,
                column: "MeasureId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "RecipesSpices",
                keyColumn: "Id",
                keyValue: 2,
                column: "MeasureId",
                value: 1);

            migrationBuilder.CreateIndex(
                name: "IX_RecipesSpices_MeasureId",
                table: "RecipesSpices",
                column: "MeasureId");

            migrationBuilder.CreateIndex(
                name: "IX_RecipesIngredients_MeasureId",
                table: "RecipesIngredients",
                column: "MeasureId");

            migrationBuilder.AddForeignKey(
                name: "FK_RecipesIngredients_Measures_MeasureId",
                table: "RecipesIngredients",
                column: "MeasureId",
                principalTable: "Measures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecipesSpices_Measures_MeasureId",
                table: "RecipesSpices",
                column: "MeasureId",
                principalTable: "Measures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RecipesIngredients_Measures_MeasureId",
                table: "RecipesIngredients");

            migrationBuilder.DropForeignKey(
                name: "FK_RecipesSpices_Measures_MeasureId",
                table: "RecipesSpices");

            migrationBuilder.DropTable(
                name: "Measures");

            migrationBuilder.DropIndex(
                name: "IX_RecipesSpices_MeasureId",
                table: "RecipesSpices");

            migrationBuilder.DropIndex(
                name: "IX_RecipesIngredients_MeasureId",
                table: "RecipesIngredients");

            migrationBuilder.DropColumn(
                name: "MeasureId",
                table: "RecipesSpices");

            migrationBuilder.DropColumn(
                name: "MeasureId",
                table: "RecipesIngredients");

            migrationBuilder.AddColumn<string>(
                name: "UnitOfMeasure",
                table: "RecipesSpices",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UnitOfMeasure",
                table: "RecipesIngredients",
                type: "nvarchar(8)",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "RecipesIngredients",
                keyColumn: "Id",
                keyValue: 1,
                column: "UnitOfMeasure",
                value: "g/kg");

            migrationBuilder.UpdateData(
                table: "RecipesIngredients",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnitOfMeasure",
                value: "g/kg");

            migrationBuilder.UpdateData(
                table: "RecipesSpices",
                keyColumn: "Id",
                keyValue: 1,
                column: "UnitOfMeasure",
                value: "g/kg");

            migrationBuilder.UpdateData(
                table: "RecipesSpices",
                keyColumn: "Id",
                keyValue: 2,
                column: "UnitOfMeasure",
                value: "g/kg");
        }
    }
}

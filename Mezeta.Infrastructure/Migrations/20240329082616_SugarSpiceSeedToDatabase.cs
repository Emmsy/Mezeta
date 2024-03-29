using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mezeta.Infrastructure.Migrations
{
    public partial class SugarSpiceSeedToDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab1d787-7a94-4813-845f-27aea5ac4c74",
                column: "ConcurrencyStamp",
                value: "d1776852-560e-4c91-8acb-ab15a649f178");

            migrationBuilder.InsertData(
                table: "Spices",
                columns: new[] { "Id", "Description", "ImageUrl", "Name" },
                values: new object[] { 10, "Захарта спомага за привличане на добрите бактерии и за зреенето на сурово-сушените колбаси", "https://img.freepik.com/free-photo/world-diabetes-day-sugar-wooden-bowl-dark-surface_1150-26666.jpg?t=st=1711700263~exp=1711703863~hmac=7df68aca69e0e19008e6359acd2ec66925e493b3e157e9ed703f2a82544ca3b1&w=1380", "Захар" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Spices",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fab1d787-7a94-4813-845f-27aea5ac4c74",
                column: "ConcurrencyStamp",
                value: "1797382a-e90f-4040-9c9e-689d7570be89");
        }
    }
}
